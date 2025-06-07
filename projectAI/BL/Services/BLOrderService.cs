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






        public async Task AddOrder(BLOrder order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var newOrder = mapper.Map<Order>(order);
            var savedOrder = await dal.Order.Create(newOrder);

            var emailItems = new List<OrderItemEmailDto>();

            foreach (var item in savedOrder.OrderItems)
            {
                string token = Guid.NewGuid().ToString("N");

                var emailLink = new EmailLink
                {
                    UserId = savedOrder.IdCustomer,
                    MovieId = item.MovieId,
                    UniqueToken = token,
                    EmailType = "NewOrder",
                    DateCreated = DateTime.UtcNow,
                    ExpirationDate = DateTime.UtcNow.AddDays(14),
                    ViewLimit = item.ViewCount,
                    ViewCount = 0
                };

                await dal.EmailLink.AddAsync(emailLink);

               
                var movie = await dal.Movie.GetMovieById(item.MovieId);
                string baseLink = $"https://localhost:7229/DosFlix/EmailLink/track";
                string fullLink = $"{baseLink}?token={token}";


                emailItems.Add(new OrderItemEmailDto
                {
                    MovieName = movie?.Name ?? "סרט ללא שם",
                    ViewerCount = item.ViewerCount,
                    ViewCount = item.ViewCount,
                    OrderLink = fullLink
                });
            }

            var user = await dal.User.GetUserById(savedOrder.IdCustomer);
            var customer = await dal.Customer.GetCustomerById(savedOrder.IdCustomer);

            if (user == null || customer == null)
                throw new InvalidOperationException("User or customer not found");

            await emailSender.SendOrderEmailAsync(
                email: user.Email,
                name: customer.FullName ?? "לקוח/ה",
                orderItems: emailItems,
                totalPrice: savedOrder.TotalAmount ?? 0
            );
        }


      
    }
}

