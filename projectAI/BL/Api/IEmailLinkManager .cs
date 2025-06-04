using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace BL.Api
{
    public interface IEmailLinkManager
    {
        Task<Result<string>> TrackClickAsync(string token, string ipAddress, string userAgent);
        Task CheckAndUpdateOrderStatusesAsync();

        Task<bool> AreAllLinksExpiredForMoviesAsync(List<int> movieIds);
    }

}
