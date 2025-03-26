
namespace Bl.Api
{
    // מה צריך להכיל שכבת הדל
    public interface IBL
    {
        public IBLCustomer Customer { get; }
        public IBLOrders Order { get; }
    }
}
