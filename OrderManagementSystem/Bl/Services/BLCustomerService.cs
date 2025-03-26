using Bl.Api;
using Dal.Api;
using Bl.Models;


namespace Bl.Services
{
    public class BLCustomerService : IBLCustomer
    {
        IDal dal;
        public BLCustomerService(IDal d)
        {
            dal = d;
        }

        public Task< List<BLCustomer>> GetAll()
        {
            throw new NotImplementedException();
        }

        //Task<List<BLCustomer>> Api.ICrud<BLCustomer>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }


}
