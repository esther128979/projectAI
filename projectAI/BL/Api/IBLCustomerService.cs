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
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Delete(Customer customer);
        Task<Customer?> GetCustomerById(int id);
    }

}
