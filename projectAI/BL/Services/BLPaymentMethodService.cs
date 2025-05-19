using BL.Api;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLPaymentMethodService : IBLPaymentMethods
    {
        public Task<List<BLPaymentMethod>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
