using Bl.Models;


namespace Bl.Api
{
    public interface IBLOrders : ICrud<BLOrder>
    {
        Task<List<BLOrder>> GetOrdersToday();
        Task<List<BLOrder>> GetOrdersByStatusFalse();
        Task<List<BLOrder>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
    }
}
