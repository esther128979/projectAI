
namespace BL.Api
{
    // מה צריך להכיל שכבת הדל
    public interface IBL
    {

        public IBLAgeGroup AgeGroup { get; }
        public IBLCategory Category { get; }
        public IBLCustomer Customer { get; }
        public IBLMovies Movies { get; }
        public IBLOrders Order { get; }

    }
}
