using BL.Api;
using DAL.Models;
using DAL.Api;

namespace BL.Services
{
    public class BLCustomerService : IBLCustomer
    {
        private readonly ICustomer _customerRepository;

        public BLCustomerService(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> Create(Customer customer)
        {
            // לוגיקה עסקית לפני יצירה (לדוגמה: אימות שדה חובה)
            return await _customerRepository.Create(customer);
        }

        public async Task<Customer> Update(Customer customer)
        {
            return await _customerRepository.Update(customer);
        }

        public async Task<Customer> Delete(Customer customer)
        {
            return await _customerRepository.Delete(customer);
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            return await _customerRepository.GetCustomerByEmail(email);
        }

        public async Task<List<Customer>> GetCustomersByPhone(string phone)
        {
            return await _customerRepository.GetCustomersByPhone(phone);
        }

        public async Task<List<Customer>> GetCustomersByGender(string gender)
        {
            return await _customerRepository.GetCustomersByGender(gender);
        }

        public async Task<List<Customer>> GetCustomersByAgeGroup(int ageGroupId)
        {
            return await _customerRepository.GetCustomersByAgeGroup(ageGroupId);
        }
    }
}
