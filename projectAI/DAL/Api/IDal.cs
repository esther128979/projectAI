

using Dal.Api;
using Dal.Models;
using DAL.Api;

namespace Dal.Api
{
    // מה צריך להכיל שכבת הדל
    public interface IDal
    {
        public ICustomer Customer { get; }
        public IOrder Order { get; }
        public ICategory Category { get; }
        public IMovie Movie { get; }
       
        //public IAgeGruop AgeGruop { get; }


    }
}
