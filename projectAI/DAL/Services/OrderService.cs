using DAL.Api;
using DAL.Models;

using Microsoft.EntityFrameworkCore;


namespace DAL.Services
{
    public class OrderService : IOrder
    {

        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .Include(o => o.IdCustomerNavigation)
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order> Create(Order order)
        {
            if (order == null || order.OrderItems == null || !order.OrderItems.Any())
                throw new ArgumentException("Invalid order");

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // ניתוק מה-Tracking כדי לא לקבל את הגרסה הישנה
            _context.Entry(order).State = EntityState.Detached;

            // שליפה מחדש מה-Database (הפעם באמת)
            var updatedOrder = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderItems)
                .Include(o => o.IdCustomerNavigation)
                .FirstOrDefaultAsync(o => o.IdOrder == order.IdOrder);

            return updatedOrder!;
        }



        public async Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersByIdCustomer(int idC)
        {
            return await _context.Orders
                .Where(o => o.IdCustomer == idC)
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersToday()
        {
            DateTime today = DateTime.UtcNow.Date;
            return await _context.Orders
                .Where(o => o.DateOrder == today)
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.DateOrder >= startDate && o.DateOrder <= endDate)
                .Include(o => o.OrderItems)
                .ToListAsync();
        }


    }
}
