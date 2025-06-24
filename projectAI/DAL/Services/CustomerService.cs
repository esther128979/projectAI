using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class CustomerService : ICustomer
    {
        private readonly AppDbContext db;

        public CustomerService(AppDbContext? context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));
        }

        // שליפת כל הלקוחות כולל ישויות מקושרות
        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await db.Customers
                    .Include(c => c.AgeGroupNavigation)
                    .Include(c => c.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת רשימת לקוחות", ex);
            }
        }

        // שליפת לקוח לפי מזהה
        public async Task<Customer?> GetCustomerById(int id)
        {
            try
            {
                return await db.Customers
                    .Include(c => c.AgeGroupNavigation)
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת לקוח לפי מזהה", ex);
            }
        }

        // שליפת לקוח לפי אימייל
        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            try
            {
                return await db.Customers
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.User.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת לקוח לפי אימייל", ex);
            }
        }

        // שליפת לקוחות לפי טלפון
        public async Task<List<Customer>> GetCustomersByPhone(string phone)
        {
            try
            {
                return await db.Customers
                    .Where(c => c.Phone == phone)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת לקוחות לפי טלפון", ex);
            }
        }

        // שליפת לקוחות לפי מגדר
        public async Task<List<Customer>> GetCustomersByGender(string gender)
        {
            try
            {
                return await db.Customers
                    .Where(c => c.Gender != null && c.Gender.ToLower() == gender.ToLower())
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת לקוחות לפי מגדר", ex);
            }
        }

        // שליפת לקוחות לפי קבוצת גיל
        public async Task<List<Customer>> GetCustomersByAgeGroup(int ageGroupId)
        {
            try
            {
                return await db.Customers
                    .Where(c => c.AgeGroup == ageGroupId)
                    .Include(c => c.AgeGroupNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשליפת לקוחות לפי קבוצת גיל", ex);
            }
        }

        // יצירת לקוח חדש
        public async Task<Customer> Create(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה ביצירת לקוח", ex);
            }
        }

        // עדכון לקוח
        public async Task<Customer> Update(Customer customer)
        {
            try
            {
                db.Customers.Update(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעדכון לקוח", ex);
            }
        }

        // מחיקת לקוח
        public async Task<Customer> Delete(Customer customer)
        {
            try
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה במחיקת לקוח", ex);
            }
        }
    }
}
