using BL.Models;
using Dal.Models;


namespace BL.Api
{
    public interface IBLOrders : IBLCrud<BLOrder>
    {
        Task<List<BLOrder>> GetOrdersToday();
        Task<List<BLOrder>> GetOrdersByStatusFalse();
        Task<List<BLOrder>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        Task AddOrder(BLOrder order);
        public  Task<List<BLOrder>> GetByIdCustomer(int idC);

    }
}
