using AutoMapper;
using BL.Models;
using server.Models;

namespace server.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // DTO ➡️ BL (יצירת סרט חדש)
            CreateMap<MovieCreateDTO, BLMovie>()
                .ForMember(dest => dest.TotalViews, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.TotalViewers, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.CodeCategory, opt => opt.MapFrom(src => src.CodeCategory ?? eCategoryGroup.Recipes))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => src.AgeGroup ?? eAgeGroup.Adult))
                .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman ?? false))
                .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.LengthMinutes))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
                .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.PriceBase))
                .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.PricePerExtraViewer))
                .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.PricePerExtraView))
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink));

            // DTO ➡️ BL (עדכון סרט קיים)
            CreateMap<MovieUpdateDTO, BLMovie>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CodeCategory, opt => opt.MapFrom(src => src.CodeCategory))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => src.AgeGroup))
                .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman))
                .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.LengthMinutes))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
                .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.PriceBase))
                .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.PricePerExtraViewer))
                .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.PricePerExtraView))
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink))
                .ForMember(dest => dest.TotalViews, opt => opt.Ignore()) // לא מעדכנים צפיות בעת עריכה
                .ForMember(dest => dest.TotalViewers, opt => opt.Ignore());

            // BL ➡️ DTO (הצגת סרט)
            CreateMap<BLMovie, MovieGetDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CodeCategoryNavigation != null ? src.CodeCategoryNavigation.CategoryDescription : null))
                .ForMember(dest => dest.AgeGroupName, opt => opt.MapFrom(src => src.AgeGroupNavigation != null ? src.AgeGroupNavigation.AgeDescription : null))
                .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.FinalPrice))
                .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.LengthMinutes ?? 0))
                .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman))
                .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.PriceBase ?? 0))
                .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.PricePerExtraViewer ?? 0))
                .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.PricePerExtraView ?? 0))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate ?? default))
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink ?? ""));
        }
    }
}
