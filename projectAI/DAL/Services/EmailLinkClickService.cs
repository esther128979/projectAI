using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

public class EmailLinkClickService : IEmailLinkClick
{
    private readonly AppDbContext _context;

    public EmailLinkClickService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(EmailLinkClick click)
    {
        await _context.EmailLinkClicks.AddAsync(click);
        await _context.SaveChangesAsync();
    }

}
