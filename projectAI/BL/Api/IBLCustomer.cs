using BL.Models;
using DAL.Models;

//using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLCustomer
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetCustomerById(int id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Delete(Customer customer);

        Task<Customer?> GetCustomerByEmail(string email);
        Task<List<Customer>> GetCustomersByPhone(string phone);
        Task<List<Customer>> GetCustomersByGender(string gender);
        Task<List<Customer>> GetCustomersByAgeGroup(int ageGroup);
    }


}
