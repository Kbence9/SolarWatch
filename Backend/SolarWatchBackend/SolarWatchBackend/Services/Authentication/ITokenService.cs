using Microsoft.AspNetCore.Identity;

namespace SolarWatchBackend.Services.Authentication;

public interface ITokenService
{
    public string CreateToken(IdentityUser user);
}