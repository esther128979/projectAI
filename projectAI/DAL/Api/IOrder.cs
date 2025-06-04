using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Api
{

    public interface IOrder : ICrud<Order>
    {
        Task<Order?> GetById(int id);
        Task<List<Order>> GetOrdersByIdCustomer(int idC);
        Task UpdateLinkForMovie(int orderItemId, string link);


    }
}
