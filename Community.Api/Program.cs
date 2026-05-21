using Community.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Services (MÅSTE komma före Build)
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// middleware (ordning är viktig!)
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapOpenApi();

app.MapGet("/api/communities", () =>
{
    var communities = new List<CommunityOption>
    {
        new CommunityOption(1, "Slack community", "112k Member", "Slack-icon.png"),
        new CommunityOption(2, "Discord HelLine", "80k Member", "discord-icon.png")
    };

    return Results.Ok(communities);
});

app.Run();