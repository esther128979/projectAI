using DAL.Models;
namespace DAL.Api
{
    public interface IEmailLink
    {
        Task AddEmailLinkAsync(EmailLink link);
        Task<EmailLink?> GetByTokenAsync(string token);
        Task<List<EmailLink>> GetLinksByUserIdAsync(int userId);

        // חדש: יצירת קישור עם טוקן
        Task<EmailLink> CreateEmailLinkAsync(int userId, int movieId, string emailType, int maxViews);

        // חדש: אימות טוקן ועדכון צפייה
        Task<bool> ValidateAndRegisterViewAsync(string token);

        // חדש: רישום לחיצה לצורכי סטטיסטיקה
        Task RegisterClickAsync(int linkId, string? ipAddress, string? userAgent);

        // חדש: ניקוי קישורים שפג תוקפם
        Task DeleteExpiredLinksAsync();
        Task<EmailLink?> GetByTokenWithClicksAndMovieAsync(string token);


        Task UpdateAsync(EmailLink link);

    }
}