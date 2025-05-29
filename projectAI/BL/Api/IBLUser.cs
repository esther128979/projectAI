using BL.Models;

namespace BL.Api
{
    public interface IBLUser : IBLCrud<BLUser>
    {
        Task<BLUser> Login(string Email, string Password);

    }
}
