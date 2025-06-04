using AutoMapper;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

public class EmailLinkService : IEmailLink
{
    private readonly AppDbContext _context;

    private readonly IMapper _mapper;

    public EmailLinkService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmailLink> UpdateAsync(EmailLink emailLink)
    {
        var existing = await _context.EmailLinks.FindAsync(emailLink.LinkId);
        if (existing == null)
            throw new InvalidOperationException("EmailLink not found");

        _mapper.Map(emailLink, existing);

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<EmailLink?> GetByTokenAsync(string token)
    {
        return await _context.EmailLinks
            .FirstOrDefaultAsync(l => l.UniqueToken == token);
    }

    public async Task<List<EmailLink>> GetAllAsync()
    {
        return await _context.EmailLinks
            .Include(l => l.Movie) // אם יש צורך
            .Include(l => l.EmailLinkClicks) // אם רלוונטי
            .ToListAsync();
    }

    public async Task<EmailLink?> GetByIdAsync(int id)
    {
        return await _context.EmailLinks
            .Include(l => l.Movie)
            .Include(l => l.EmailLinkClicks)
            .FirstOrDefaultAsync(l => l.LinkId == id);
    }

    public async Task<EmailLink> AddAsync(EmailLink emailLink)
    {
        _context.EmailLinks.Add(emailLink);
        await _context.SaveChangesAsync();
        return emailLink;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var link = await _context.EmailLinks.FindAsync(id);
        if (link == null)
            return false;

        _context.EmailLinks.Remove(link);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task AddClickAsync(EmailLinkClick click)
    {
        _context.EmailLinkClicks.Add(click);
        
        await _context.SaveChangesAsync();
    }
    public async Task<List<EmailLink>> GetEmailLinksByMovieIdsAsync(List<int> movieIds)
    {
        return await _context.EmailLinks
            .Where(l => movieIds.Contains(l.MovieId))
            .ToListAsync();
    }

    public async Task<int> GetClickCountByLinkIdAsync(int linkId)
    {
        return await _context.EmailLinkClicks
            .CountAsync(c => c.LinkId == linkId);
    }

  
}
