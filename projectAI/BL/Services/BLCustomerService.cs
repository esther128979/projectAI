using BL.Api;
using DAL.Models;

public class BLCustomerService : IBLCustomer
{
    private readonly IBLCustomer _customerRepository;

    public BLCustomerService(IBLCustomer customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> GetAll()
    {
        // כאן אפשר להוסיף לוגיקה עסקית לפני או אחרי הקריאה ל-DAL
        return await _customerRepository.GetAll();
    }

    public async Task<Customer> Create(Customer customer)
    {
        // אפשר לבדוק תקינות, ולוגיקות נוספות פה
        return await _customerRepository.Create(customer);
    }

    public async Task<Customer> Update(Customer customer)
    {
        // בדיקות לוגיקה עסקית
        return await _customerRepository.Update(customer);
    }

    public async Task<Customer> Delete(Customer customer)
    {
        // לוגיקה למחיקה, למשל בדיקות הרשאות
        return await _customerRepository.Delete(customer);
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        return await _customerRepository.GetCustomerById(id);
    }
}
