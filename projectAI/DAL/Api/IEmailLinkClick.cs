using DAL.Models;
namespace DAL.Api
{
    public interface IEmailLinkClick
    {
        Task AddAsync(EmailLinkClick click);

    }
}