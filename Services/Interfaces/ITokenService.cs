using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}