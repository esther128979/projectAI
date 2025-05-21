using BL.Api;
using DAL.Api;
using DAL.Models;
using BL.Models;



namespace BL.Services
{
    //לעשות כאן MAPPING
    public class BLCustomerService : IBLCustomer
    {
        IDAL dal;
        public BLCustomerService(IDAL d)
        {
            dal = d;
        }

        public async Task<List<BLCustomer>> GetAll()
        {
            throw new NotImplementedException();
            //List<Customer> list = await dal.Customer.GetAll();
            //return list.Select(c => new BLCustomer()
            //{
            //    CustomerId = c.CustomerId,
            //    CustomerNumber = c.CustomerNumber,
            //    CustomerName = c.CustomerName,
            //    Phone = c.Phone,
            //    Email = c.Email,
            //    Password = c.Password,
            //    Gender = (eGender)Enum.Parse(typeof(eGender), c.Gender),
            //    AgeGroup = c.AgeGroup,
            //    ProfilePicture = c.ProfilePicture,
            //    AgeGroupNavigation = (eAgeGroup)Enum.Parse(typeof(eAgeGroup), c.AgeGroupNavigation.AgeDescrepition)
            //}).ToList();
        }


    }


}
