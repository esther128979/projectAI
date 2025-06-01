using BL.Models;

namespace BL.Api
{
    public interface IBLUser : IBLCrud<BLUser>
    {
        Task<BLUser?> Login(string email, string password);
        Task<BLUser> Register(RegisterRequest registerRequest);
    }
}
