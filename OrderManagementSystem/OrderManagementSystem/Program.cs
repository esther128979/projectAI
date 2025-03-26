using Bl;
using Bl.Api;
using Bl.Services;
using Bl.Models;


namespace OrderManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            IBL bl = new BlManager();


            var list = await bl.Order.GetAll();
            foreach (BLOrder o in list)
            {
                Console.WriteLine("Order ID number:" + o.IdOrder + " "
                                  + o.DateOrder.ToString("dd/MM/yyyy"));
            }
            var list1 = await bl.Order.GetAll();
            await BLOrderService.GenerateOrdersPdf(list);
        }
    }
}


//https://github.com/esther128979/projectAI.git
