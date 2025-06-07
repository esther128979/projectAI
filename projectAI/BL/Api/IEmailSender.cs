using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.Api
{
    public interface IEmailSender
    {
        Task<bool> SendOrderEmailAsync(string email, string name, List<OrderItemEmailDto> orderItems, decimal totalPrice);
    }

}
