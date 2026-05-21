using Community.Api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();

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