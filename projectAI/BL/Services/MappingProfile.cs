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
            CreateMap<Movie, BLMovie>()
            .ForMember(dest => dest.ageGroup,
                       opt => opt.MapFrom(src => (eAgeGroup)(src.AgeCode ?? 0))) // המרת int? ל-enum
            .ForMember(dest => dest.CodeCategory,
                       opt => opt.MapFrom(src => (eCategoryGroup)(src.CodeCategory ?? 0))) // המרת int? ל-enum
            .ForMember(dest => dest.AgeCodeNavigation,
                       opt => opt.MapFrom(src => src.AgeCodeNavigation)) // מיפוי אובייקט פנימי
            .ForMember(dest => dest.CodeCategoryNavigation,
                       opt => opt.MapFrom(src => src.CodeCategoryNavigation));


            //.ForMember(dest => dest.Link,
            //           opt => opt.MapFrom(src => src.Link))
            //.ForMember(dest => dest.Id,
            //           opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.ThereIsWoman,
            //           opt => opt.MapFrom(src => src.ThereIsWoman))
            //.ForMember(dest => dest.Length,
            //           opt => opt.MapFrom(src => src.Length))
            //.ForMember(dest => dest.AmountOfUses,
            //           opt => opt.MapFrom(src => src.AmountOfUses))
            //.ForMember(dest => dest.FilmProductionDate,
            //           opt => opt.MapFrom(src => src.FilmProductionDate))
            //.ForMember(dest => dest.Price,
            //           opt => opt.MapFrom(src => src.Price));

            // אם יש לך גם מיפוי חזרה:
            CreateMap<BLMovie, Movie>()
                .ForMember(dest => dest.AgeCode,
                           opt => opt.MapFrom(src => (int?)src.ageGroup))
                .ForMember(dest => dest.CodeCategory,
                           opt => opt.MapFrom(src => (int?)src.CodeCategory));
            // שאר השדות יימופו אוטומטית




        }
    }
}
