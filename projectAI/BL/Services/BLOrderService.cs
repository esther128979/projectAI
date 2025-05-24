using BL.Api;
using DAL.Api;
using BL.Models;
using DAL.Models;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Colors;

using AutoMapper;

namespace BL.Services
{
    public class BLOrderService : IBLOrders
    {
        private readonly IDAL dal;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender; 

        public BLOrderService(IDAL d, IMapper mapper, IEmailSender emailSender)
        {
            dal = d;
            this.mapper = mapper;
            this.emailSender = emailSender;
        }
        public async Task<List<BLOrder>> GetAll()
        {
            List<Order> list = await dal.Order.GetAll();
            return mapper.Map<List<BLOrder>>(list);
        }

        public async Task<List<BLOrder>> GetByIdCustomer(int idC)
        {
            //בדיקה אם הלקוח קיים
            var customer = await dal.Customer.GetCustomerById(idC);
            if (customer == null)
                throw new Exception("The customer does not exist in the system.");

            // שליפת ההזמנות של הלקוח
            var orders = await dal.Order.GetOrdersByIdCustomer(idC);

            return mapper.Map<List<BLOrder>>(orders);

        }



        public async Task<List<BLOrder>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > DateTime.Today || endDate > DateTime.Today)
                throw new Exception("Incorrect date range.");

            List<Order> list2 = await dal.Order.GetOrdersByDateRange(startDate, endDate);

            return mapper.Map<List<BLOrder>>(list2);
        }


        public async Task<List<BLOrder>> GetOrdersToday()
        {
            List<Order> list3 = await dal.Order.GetOrdersToday();
            return mapper.Map<List<BLOrder>>(list3);
        }


        public async Task AddOrder(BLOrder order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            // ממפה BLOrder ל-Order (המודל של DAL)
            Order newOrder = mapper.Map<Order>(order);

            // שומר את ההזמנה ב-DAL ומחזיר את ההזמנה עם הפרטים המלאים כולל מזהה
            var savedOrder = await dal.Order.Create(newOrder);

            //שימולב!!
            //אחרי שנעשה בו מפינג כמובן 
            //לשנות את זה שניקח את זה מתוך אוביקיט של BL שיש בו מייל
            var user = await dal.User.GetUserById(savedOrder.IdCustomer);
            var customer = await dal.Customer.GetCustomerById(savedOrder.IdCustomer);

            // יוצר טוקנים ושומר לטבלה EmailLinks
            foreach (var detail in savedOrder.OrderItems)
            {
                string token = Guid.NewGuid().ToString("N");

                var emailLink = new EmailLink
                {
                    UserId = savedOrder.IdCustomer,
                    MovieId = detail.MovieId,
                    UniqueToken = token,
                    EmailType = "NewOrder",
                    DateCreated = DateTime.UtcNow,
                    ExpirationDate = DateTime.UtcNow.AddDays(14) // תוקף של שבועיים
                };

                await dal.EmailLink.AddEmailLinkAsync(emailLink);

                // שיחרור קישור לצפייה (הנחה: יש לך שדה Link בסרט)
                var movie = await dal.Movie.GetMovieById(detail.MovieId);
                string baseLink = movie?.Link ?? "https://defaultlink.com";

                string fullLink = $"{baseLink}?token={token}";
                // שליחת מייל עם הקישור דרך שירות מייל
                await emailSender.SendOrderEmailAsync(
                    email: user.Email,
                    name: customer.FullName,
                    movieName: movie.Name,
                    orderLink: fullLink, 
                    viewerCount: detail.ViewerCount,
                    viewCount:detail.ViewCount,
                    totalPrice: (decimal)savedOrder.TotalAmount
                );
            }
        }

    }
}

