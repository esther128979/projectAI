using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IEmailSender
    {
        Task<bool> SendOrderEmailAsync(string email, string name, string movieName, string orderLink, int viewerCount, int viewCount, decimal totalPrice);
    }

}
