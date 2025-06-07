
namespace BL.Api
{
    // מה צריך להכיל שכבת הדל
    public interface IBL
    {

        public IBLAgeGroup AgeGroup { get; }
        public IBLCategory Category { get; }
        public IBLUser User { get; }
        public IBLMovies Movies { get; }
        public IBLOrders Order { get; }
        public IEmailSender EmailSender { get;  }
        public IEmailLinkManager EmailLinkManager { get; }

    }
}
