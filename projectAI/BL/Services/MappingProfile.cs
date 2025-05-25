using AutoMapper;
using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Services
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            #region MovieMapping
            CreateMap<Movie, BLMovie>()
                .ForMember(dest => dest.CodeCategory, opt => opt.MapFrom(src => (eCategoryGroup)(src.CategoryCode ?? 0)))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => (eAgeGroup)(src.AgeCode ?? 0)))
                .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.ThereIsWoman ?? false))
                .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.FilmProductionDate))
                .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.BasePrice))
                .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.ExtraViewerPrice))
                .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.ExtraViewPrice))
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.Link))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.CodeCategoryNavigation, opt => opt.MapFrom(src => src.CategoryCodeNavigation))
                .ForMember(dest => dest.AgeGroupNavigation, opt => opt.MapFrom(src => src.AgeCodeNavigation))
                .ForMember(dest => dest.TotalViewers,
                    opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.ViewerCount)))
                .ForMember(dest => dest.TotalViews,
                    opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.ViewCount)));

            CreateMap<BLMovie, Movie>()
                .ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => (int?)src.CodeCategory))
                .ForMember(dest => dest.AgeCode, opt => opt.MapFrom(src => (int?)src.AgeGroup))
                .ForMember(dest => dest.ThereIsWoman, opt => opt.MapFrom(src => src.HasWoman))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.LengthMinutes))
                .ForMember(dest => dest.AmountOfViews, opt => opt.MapFrom(src => src.TotalViews))
                .ForMember(dest => dest.FilmProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
                .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.PriceBase))
                .ForMember(dest => dest.ExtraViewerPrice, opt => opt.MapFrom(src => src.PricePerExtraViewer))
                .ForMember(dest => dest.ExtraViewPrice, opt => opt.MapFrom(src => src.PricePerExtraView))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.MovieLink))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));




            #endregion

            #region AgeGroup

            CreateMap<AgeGroup, BLAgeGroup>()
    .ForMember(dest => dest.AgeCode, opt => opt.MapFrom(src => src.AgeCode))
    .ForMember(dest => dest.AgeDescrepition, opt => opt.MapFrom(src => src.AgeDescription))
    .ForMember(dest => dest.Movies, opt => opt.Ignore()) // כדי למנוע לולאות רקורסיביות
    .ForMember(dest => dest.Users, opt => opt.Ignore()); // כנ"ל

            CreateMap<BLAgeGroup, AgeGroup>()
    .ForMember(dest => dest.Movies, opt => opt.Ignore())
    .ForMember(dest => dest.Customers, opt => opt.Ignore());




            #endregion

            #region Category

            CreateMap<Category, BLCategory>()
    .ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => src.CategoryCode))
    .ForMember(dest => dest.CategoryDescreption, opt => opt.MapFrom(src => src.CategoryDescription))
    .ForMember(dest => dest.Movies, opt => opt.Ignore()); // להימנע מרקורסיה

            CreateMap<BLCategory, Category>()
               .ForMember(dest => dest.Movies, opt => opt.Ignore());

            #endregion

            #region User+Customer to BLUser

            CreateMap<User, BLUser>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (eRole)src.RoleId))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FullName : null))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Phone : null))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src =>
                    src.Customer != null && src.Customer.Gender == "Male" ? eGender.Male :
                    src.Customer != null && src.Customer.Gender == "Female" ? eGender.Female : eGender.Male))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src =>
                    src.Customer != null ? (eAgeGroup?)src.Customer.AgeGroup : null))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.ProfilePicture : null))
                .ForMember(dest => dest.EmailLinks, opt => opt.Ignore()) // אפשר להשלים לפי הצורך
                .ForMember(dest => dest.Orders, opt => opt.Ignore());

            CreateMap<BLUser, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => (int)src.Role))
                .ForMember(dest => dest.Customer, opt => opt.Ignore()); // נטפל ב־Customer בנפרד אם צריך

CreateMap<BLUser, Customer>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src =>
        src.Gender == eGender.Male ? "Male" : "Female"))
    .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => (int?)src.AgeGroup))
    .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
    .ForMember(dest => dest.User, opt => opt.Ignore())
    .ForMember(dest => dest.AgeGroupNavigation, opt => opt.Ignore())
    .ForMember(dest => dest.EmailLinks, opt => opt.Ignore())
    .ForMember(dest => dest.Orders, opt => opt.Ignore());



            #endregion

            #region Order

            // DAL ➡️ BL
            CreateMap<Order, BLOrder>()
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom(src => src.Status ? eStatus.Completed : eStatus.InProgress))
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore()) // אם צריך
                .ForMember(dest => dest.TotalAmount,
                           opt => opt.MapFrom(src => src.TotalAmount)); // ✅ מיפוי חד-כיווני

            // BL ➡️ DAL (שולחים חזרה לדאטהבייס)
            CreateMap<BLOrder, Order>()
      .ForMember(dest => dest.Status,
                 opt => opt.MapFrom(src => src.Status == eStatus.Completed))
      .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems)) 
      .ForMember(dest => dest.TotalAmount,
                 opt => opt.Ignore()); // DB calculates this

            #endregion

            #region OrderItem

            CreateMap<OrderItem, BLOrderItem>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
       .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
       .ForMember(dest => dest.ViewerCount, opt => opt.MapFrom(src => src.ViewerCount))
       .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => src.ViewCount))
       .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.SubTotal))
       .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie));

            CreateMap<BLOrderItem, OrderItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.ViewerCount, opt => opt.MapFrom(src => src.ViewerCount))
                .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => src.ViewCount))
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.SubTotal))
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore());


            #endregion

            #region EmailLink
            CreateMap<EmailLink, BLEmailLink>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LinkId))
             .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.UniqueToken))
             .ForMember(dest => dest.SentAt, opt => opt.MapFrom(src => src.DateCreated));
            CreateMap<BLEmailLink, EmailLink>()
            .ForMember(dest => dest.LinkId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.UniqueToken, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.SentAt))
            .ForMember(dest => dest.MovieId, opt => opt.Ignore()) // כי אין אותו ב-BL
            .ForMember(dest => dest.EmailType, opt => opt.Ignore())
            .ForMember(dest => dest.ExpirationDate, opt => opt.Ignore())
            .ForMember(dest => dest.EmailLinkClicks, opt => opt.Ignore())
            .ForMember(dest => dest.Movie, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore());

            #endregion


        }
    }
}
