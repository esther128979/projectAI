using BL.Api;
using Dal.Api;
using BL.Models;
using Dal.Models;
using DAL.Models;


namespace BL.Services
{
    public class BLCustomerService : IBLCustomer
    {
        IDal dal;
        public BLCustomerService(IDal d)
        {
            dal = d;
        }

        public async Task<List<BLCustomer>> GetAll()
        {
            List<Customer> list = await dal.Customer.GetAll();
            return list.Select(c => new BLCustomer()
            {
                CustomerId = c.CustomerId,
                CustomerNumber = c.CustomerNumber,
                CustomerName = c.CustomerName,
                Phone = c.Phone,
                Email = c.Email,
                Password = c.Password,
                Gender = (eGender)Enum.Parse(typeof(eGender), c.Gender),
                AgeGroup = c.AgeGroup,
                ProfilePicture = c.ProfilePicture,
                AgeGroupNavigation = (eAgeGroup)Enum.Parse(typeof(eAgeGroup), c.AgeGroupNavigation.AgeDescrepition)
            }).ToList();
        }


    }


}
