using DAL.Models;
namespace DAL.Api
{
    public interface IEmailLink
    {
        Task<EmailLink?> GetByTokenAsync(string token);
        Task<List<EmailLink>> GetAllAsync();
        Task<EmailLink?> GetByIdAsync(int id);
        Task<EmailLink> AddAsync(EmailLink emailLink);
        Task<EmailLink> UpdateAsync(EmailLink emailLink);
        Task<bool> DeleteByIdAsync(int id);

        Task AddClickAsync(EmailLinkClick click);
        Task<List<EmailLink>> GetEmailLinksByMovieIdsAsync(List<int> movieIds);
        Task<int> GetClickCountByLinkIdAsync(int linkId);

    }
}