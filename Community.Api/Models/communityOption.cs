using System.Security.Cryptography.X509Certificates;
namespace Community.Api.Models
{
    public record CommunityOption(
        int Id,
        string CommunityName,
        string NumberOfMembers,
        string IconUrl
    );
}


