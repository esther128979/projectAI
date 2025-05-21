using AutoMapper;
using BL.Models;
//using DAL.Models;
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

    //        #region MovieMapping
    //        CreateMap<Movie, BLMovie>()
    //        .ForMember(dest => dest.ageGroup,
    //                   opt => opt.MapFrom(src => (eAgeGroup)(src.AgeCode ?? 0))) // המרת int? ל-enum
    //        .ForMember(dest => dest.CodeCategory,
    //                   opt => opt.MapFrom(src => (eCategoryGroup)(src.CodeCategory ?? 0))) // המרת int? ל-enum
    //        .ForMember(dest => dest.AgeCodeNavigation,
    //                   opt => opt.MapFrom(src => src.AgeCodeNavigation)) // מיפוי אובייקט פנימי
    //        .ForMember(dest => dest.CodeCategoryNavigation,
    //                   opt => opt.MapFrom(src => src.CodeCategoryNavigation));


    //        //.ForMember(dest => dest.Link,
    //        //           opt => opt.MapFrom(src => src.Link))
    //        //.ForMember(dest => dest.Id,
    //        //           opt => opt.MapFrom(src => src.Id))
    //        //.ForMember(dest => dest.ThereIsWoman,
    //        //           opt => opt.MapFrom(src => src.ThereIsWoman))
    //        //.ForMember(dest => dest.Length,
    //        //           opt => opt.MapFrom(src => src.Length))
    //        //.ForMember(dest => dest.AmountOfUses,
    //        //           opt => opt.MapFrom(src => src.AmountOfUses))
    //        //.ForMember(dest => dest.FilmProductionDate,
    //        //           opt => opt.MapFrom(src => src.FilmProductionDate))
    //        //.ForMember(dest => dest.Price,
    //        //           opt => opt.MapFrom(src => src.Price));

    //        // אם יש לך גם מיפוי חזרה:
    //        CreateMap<BLMovie, Movie>()
    //            .ForMember(dest => dest.AgeCode,
    //                       opt => opt.MapFrom(src => (int?)src.ageGroup))
    //            .ForMember(dest => dest.CodeCategory,
    //                       opt => opt.MapFrom(src => (int?)src.CodeCategory));
    //        // שאר השדות יימופו אוטומטית

    //        #endregion

    //        #region AgeGroup

    //        CreateMap<AgeGroup, BLAgeGroup>()
    //.ForMember(dest => dest.AgeCode, opt => opt.MapFrom(src => src.AgeCode))
    //.ForMember(dest => dest.AgeDescrepition, opt => opt.MapFrom(src => src.AgeDescrepition))
    //.ForMember(dest => dest.Movies, opt => opt.Ignore()) // כדי למנוע לולאות רקורסיביות
    //.ForMember(dest => dest.Customers, opt => opt.Ignore()); // כנ"ל

    //        CreateMap<BLAgeGroup, AgeGroup>()
    //.ForMember(dest => dest.Movies, opt => opt.Ignore())
    //.ForMember(dest => dest.Customers, opt => opt.Ignore());




    //        #endregion

    //        #region Category

    //        CreateMap<Category, BLCategory>()
    //.ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => src.CategoryCode))
    //.ForMember(dest => dest.CategoryDescreption, opt => opt.MapFrom(src => src.CategoryDescreption))
    //.ForMember(dest => dest.Movies, opt => opt.Ignore()); // להימנע מרקורסיה

    //        CreateMap<BLCategory, Category>()
    //           .ForMember(dest => dest.Movies, opt => opt.Ignore());

    //        #endregion

    //        #region Customer
    //        CreateMap<Customer, BLCustomer>()
    //.ForMember(dest => dest.Gender,
    //           opt => opt.MapFrom(src => src.Gender == "Female" ? eGender.Female :
    //                                      src.Gender == "Male" ? eGender.Male :eGender.Female  )) // התאימי לפי השימוש שלך
    //.ForMember(dest => dest.AgeGroupNavigation,
    //           opt => opt.MapFrom(src => (eAgeGroup)(src.AgeGroup ?? 0)))
    //.ForMember(dest => dest.Order,
    //           opt => opt.MapFrom(src => src.Order));


    //        CreateMap<BLCustomer, Customer>()
    //.ForMember(dest => dest.Gender,
    //           opt => opt.MapFrom(src => src.Gender == eGender.Female ? "Female" :
    //                                      src.Gender == eGender.Male ? "Male" : null))
    //.ForMember(dest => dest.AgeGroup,
    //           opt => opt.MapFrom(src => (int?)src.AgeGroup)) // או src.AgeGroup אם עדיף לך
    //.ForMember(dest => dest.Order,
    //           opt => opt.MapFrom(src => src.Order));

    //        #endregion

    //        #region Order

    //        // מיפוי מ-DAL ל-BL
    //        CreateMap<Order, BLOrder>()
    //            .ForMember(dest => dest.Status,
    //                       opt => opt.MapFrom(src => src.Status ? eStatus.Completed : eStatus.InProgress))
    //            .ForMember(dest => dest.MoviesList, // אם אין Movies ב-Order, התעלמי מזה או הוסף ממקור אחר
    //                       opt => opt.Ignore()); // ממלאים ממקום אחר או משאירים ריק

    //        // מיפוי מ-BL ל-DAL
    //        CreateMap<BLOrder, Order>()
    //            .ForMember(dest => dest.Status,
    //                       opt => opt.MapFrom(src => src.Status == eStatus.Completed)) // אם Completed – true
    //            .ForMember(dest => dest.IdOrderNavigation,
    //                       opt => opt.Ignore()); // שדה ניווט – לא ממפים אותו מ-id



    //        #endregion

    //        #region OrderDetails

    //        CreateMap<OrderDetail, BLOrderDetail>()
    //.ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => src.CategoryCode))
    //.ForMember(dest => dest.UsageDays, opt => opt.MapFrom(src => src.UsageDays))
    //.ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.OrderCode));

    //        CreateMap<BLOrderDetail, OrderDetail>()
    //            .ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => src.CategoryCode))
    //            .ForMember(dest => dest.UsageDays, opt => opt.MapFrom(src => src.UsageDays))
    //            .ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.OrderCode));


    //        #endregion

    //        #region PaymentMethod

    //        CreateMap<PaymentMethod, BLPaymentMethod>().ReverseMap();

    //        #endregion
        }
    }
}
