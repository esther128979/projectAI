using BL.Models;
//using DAL.Models;


namespace BL.Api
{
    public interface IBLOrders : IBLCrud<BLOrder>
    {
  
        Task AddOrder(BLOrder order);
        public  Task<List<BLOrder>> GetByIdCustomer(int idC);


    }
}
