using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

public class EmailLinkService : IEmailLink
{
    private readonly AppDbContext _context;

    public EmailLinkService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddEmailLinkAsync(EmailLink link)
    {
        if (link == null) throw new ArgumentNullException(nameof(link));
        _context.EmailLinks.Add(link);
        await _context.SaveChangesAsync();
    }

    public async Task<EmailLink?> GetByTokenAsync(string token)
    {
        return await _context.EmailLinks.FirstOrDefaultAsync(l => l.UniqueToken == token);
    }

    public async Task<List<EmailLink>> GetLinksByUserIdAsync(int userId)
    {
        return await _context.EmailLinks
            .Where(l => l.UserId == userId)
            .ToListAsync();
    }

    public async Task<EmailLink> CreateEmailLinkAsync(int userId, int movieId, string emailType, int maxViews)
    {
        var movie = await _context.Movies.FindAsync(movieId);
        if (movie == null || string.IsNullOrEmpty(movie.Link))
            throw new Exception("סרט לא נמצא או שאין לו קישור");

        string token = Guid.NewGuid().ToString("N");

        var emailLink = new EmailLink
        {
            UserId = userId,
            MovieId = movieId,
            UniqueToken = token,
            EmailType = emailType,
            DateCreated = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddDays(14),
           
        };

        _context.EmailLinks.Add(emailLink);
        await _context.SaveChangesAsync();

        return emailLink;
    }

    public async Task<bool> ValidateAndRegisterViewAsync(string token)
    {
        var link = await _context.EmailLinks
            .Include(l => l.Movie) // טוען את הסרט יחד עם הלינק
            .FirstOrDefaultAsync(l => l.UniqueToken == token);

        if (link == null ||
            (link.ExpirationDate.HasValue && link.ExpirationDate.Value < DateTime.UtcNow))
        {
            return false;
        }

        // אם יש סרט, מגדילים את ספירת הצפיות
        if (link.Movie != null)
        {
            link.Movie.AmountOfViews += 1;
        }

        await _context.SaveChangesAsync();

        return true;
    }


    public async Task RegisterClickAsync(int linkId, string? ipAddress, string? userAgent)
    {
        var click = new EmailLinkClick
        {
            LinkId = linkId,
            ClickDate = DateTime.UtcNow,
            Ipaddress = ipAddress,
            UserAgent = userAgent,
            Converted = false
        };

        _context.EmailLinkClicks.Add(click);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExpiredLinksAsync()
    {
        var expired = await _context.EmailLinks
            .Where(l => l.ExpirationDate < DateTime.UtcNow)
            .ToListAsync();

        _context.EmailLinks.RemoveRange(expired);
        await _context.SaveChangesAsync();
    }
    public async Task<EmailLink> GetByTokenWithClicksAndMovieAsync(string token)
    {
        return await _context.EmailLinks
            .Include(l => l.EmailLinkClicks)
            .Include(l => l.Movie)
            .FirstOrDefaultAsync(l => l.UniqueToken == token);
    }

    public async Task UpdateAsync(EmailLink link)
    {
        _context.EmailLinks.Update(link);
        
        await _context.SaveChangesAsync();
    }

}
