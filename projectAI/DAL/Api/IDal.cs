


namespace DAL.Api
{
    public interface IDAL
    {
        public ICustomer Customer { get; }
        public IOrder Order { get; }
        public ICategory Category { get; }
        public IMovie Movie { get; }
        public IUser User { get; }

        //public IAgeGruop AgeGruop { get; }

        public IEmailLink EmailLink { get; }



    }
}
