

using DAL.Api;

namespace Dal.Api
{
    // מה צריך להכיל שכבת הדל
    public interface IDal
    {
        public ICustomer Customer { get; }
        public IOrder Order { get; }
        public IMovies Movies { get; }

    }
}
