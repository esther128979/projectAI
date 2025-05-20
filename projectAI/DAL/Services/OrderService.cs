using DAL.Api;
using DAL.Models;

using Microsoft.EntityFrameworkCore;


namespace DAL.Services
{
    public class OrderService : IOrder
    {
        mycontext db;
        public OrderService(mycontext? m)
        {
            db = m;
        }
        public async Task<List<Order>> GetAll()
        {
            try
            {
                return  db.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders", ex);

            }
        }
       //החזרת הזמנות של לקוח ספציפי
       //ביצוע בדיקה בביאל שקיים באמת לקוח כזה במאגר
        public async Task<List<Order>> GetOrdersByIdCustomer(int idC)
        {
            try
            {
                return db.Orders.Where(o => o.IdCustomer == idC).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders", ex);

            }
        }
        //החזרת רשימת ההזמנות שהתבצעה היום
        public async Task<List<Order>> GetOrdersToday()
        {
            try
            {
                return db.Orders.Where(o => o.DateOrder==DateTime.Today).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders", ex);
            }
        }
        public async Task<List<Order>> GetOrdersByStatusFalse()
        {
            try
            {
                return db.Orders.Where(o => o.Status == false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders", ex);
            }
        }
        public async Task<List<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await db.Orders.Where(o => o.DateOrder >= startDate && o.DateOrder <= endDate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders", ex);
            }
        }

        public async Task<Order> Create(Order t)
        {
            try
            {
                await db.Orders.AddAsync(t);
                await db.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה ביצירת הזמנה", ex);
            }
        }

        public async Task<Order?> Update(Order t)
        {
            try
            {
                var existing = await db.Orders.FindAsync(t.IdOrder);
                if (existing == null)
                    return null;

                // עדכון שדות (מותאם לשדות שבמודל שלך)
                existing.IdCustomer = t.IdCustomer;
                existing.DateOrder = t.DateOrder;
                existing.TotalAmount = t.TotalAmount;
                // וכו'

                await db.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעדכון הזמנה", ex);
            }
        }

        public async Task<Order> Delete(Order order)
        {
            try
            {
                var existingOrder = await db.Orders.FindAsync(order.IdOrder);
                if (existingOrder == null)
                    return null;

                db.Orders.Remove(existingOrder);
                await db.SaveChangesAsync();
                return existingOrder;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order", ex);
            }
        }


    }
}
