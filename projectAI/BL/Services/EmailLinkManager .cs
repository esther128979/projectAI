using AutoMapper;
using BL.Api;
using BL.Models;
using CSharpFunctionalExtensions;
using DAL.Api;
using DAL.Models;

public class EmailLinkManager: IEmailLinkManager
{
    private readonly IDAL _dal;
    private readonly IMapper _mapper;

    public EmailLinkManager(IDAL emailLinkService, IMapper mapper)
    {
        _dal = emailLinkService;
        _mapper = mapper;
    }

    public async Task<int> CreateEmailLinkAsync(BLEmailLink blEmailLink)
    {
        var emailLink = _mapper.Map<EmailLink>(blEmailLink);
        var created = await _dal.EmailLink.AddAsync(emailLink);
        return created.LinkId;
    }

    public async Task<bool> RegisterClickAsync(string token, string ipAddress)
    {
        var emailLink = await _dal.EmailLink.GetByTokenAsync(token);
        if (emailLink == null)
            return false;

        var click = new EmailLinkClick
        {
            LinkId = emailLink.LinkId,
            ClickDate = DateTime.UtcNow,
            Ipaddress = ipAddress
        };

        await _dal.EmailLink.AddClickAsync(click);
        return true;
    }

    public async Task<List<BLEmailLink>> GetAllAsync()
    {
        var emailLinks = await _dal.EmailLink.GetAllAsync();
        return _mapper.Map<List<BLEmailLink>>(emailLinks);
    }

    public async Task<BLEmailLink?> GetByIdAsync(int id)
    {
        var emailLink = await _dal.EmailLink.GetByIdAsync(id);
        return _mapper.Map<BLEmailLink?>(emailLink);
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        return await _dal.EmailLink.DeleteByIdAsync(id);
    }
    public async Task<bool> AreAllLinksExpiredForMoviesAsync(List<int> movieIds)
    {
        var now = DateTime.UtcNow;
        var links = await _dal.EmailLink.GetEmailLinksByMovieIdsAsync(movieIds);

        var validMovies = new HashSet<int>();

        foreach (var link in links)
        {
            bool isValid =
     (!link.ExpirationDate.HasValue || link.ExpirationDate.Value > now) &&
     (link.ViewLimit == 0 || link.ViewCount < link.ViewLimit);

            if (isValid)
            {
                validMovies.Add(link.MovieId);
            }

        }

        // אם כל הסרטים נמצאים בסט תקין, מחזיר false (יש לפחות קישור תקף)
        // אחרת מחזיר true (כל הקישורים לתקופה פגו)
        return movieIds.All(id => !validMovies.Contains(id));
    }

    public async Task<Result<string>> TrackClickAsync(string token, string ipAddress, string userAgent)
    {
        if (string.IsNullOrWhiteSpace(token))
            return Result.Failure<string>("Token is required.");

        var emailLink = await _dal.EmailLink.GetByTokenAsync(token);
        if (emailLink == null)
            return Result.Failure<string>("Link not found.");

        if (emailLink.ExpirationDate.HasValue && emailLink.ExpirationDate.Value < DateTime.UtcNow)
            return Result.Failure<string>("Link has expired.");

        // בדיקת מגבלת צפיות אם קיימת
        if (emailLink.ViewLimit > 0 && emailLink.ViewCount >= emailLink.ViewLimit)
            return Result.Failure<string>("View limit exceeded.");

        // עדכון כמות צפיות
        emailLink.ViewCount += 1;
        emailLink.Movie.AmountOfViews += 1;
        await _dal.EmailLink.UpdateAsync(emailLink);

        // רישום לחיצה
        var click = new EmailLinkClick
        {
            LinkId = emailLink.LinkId,
            ClickDate = DateTime.UtcNow,
            Ipaddress = ipAddress,
            UserAgent = userAgent,
            Converted = false
        };

        await _dal.EmailLink.AddClickAsync(click);
        //string movieWatchUrl = $"https://dosflix.com/Watch?movieId={emailLink.MovieId}&token={token}";
        Movie movie =await _dal.Movie.GetMovieById(emailLink.MovieId);
        string movieWatchUrl = movie.Link;

        //עדכון ססטוס הזמנה
        CheckAndUpdateOrderStatusesAsync();
        return Result.Success<string>(movieWatchUrl);

    }
    public async Task CheckAndUpdateOrderStatusesAsync()
    {
        var orders = await _dal.Order.GetAll();

        foreach (var order in orders)
        {
            var movieIds = order.OrderItems.Select(oi => oi.MovieId).ToList();

            bool allLinksExpired = await this.AreAllLinksExpiredForMoviesAsync(movieIds);

            if (allLinksExpired && order.Status)
            {
                order.Status = false;
                await _dal.Order.Update(order);
            }
        }
    }

}
