

using DAL.Api;
using DAL.Models;
using DAL.Api;

namespace DAL.Api
{
    // מה צריך להכיל שכבת הדל
    public interface IDAL
    {
        public ICustomer Customer { get; }
        public IOrder Order { get; }
        public ICategory Category { get; }
        public IMovie Movie { get; }
       
        //public IAgeGruop AgeGruop { get; }


    }
}
