using System.Reflection;
using AutoMapper;
using BL.Models;
using iText.Svg.Renderers.Path.Impl;
using Microsoft.OpenApi.Attributes;
using server.Models;

namespace server.Profiles
{
    public class MovieProfile : Profile
    {
        public static string? GetDisplayName(Enum? value)
        {
            if (value == null)
                return null;

            var type = value.GetType();
            var member = type.GetMember(value.ToString()!);
            var attr = member[0].GetCustomAttribute<DisplayAttribute>();

            return attr?.Name ?? value.ToString();
        }
        public MovieProfile()
        {

            // DTO ➡️ BL (יצירת סרט חדש)
            CreateMap<MovieCreateDTO, BLMovie>()
                .ForMember(dest => dest.TotalViews, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.TotalViewers, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.CodeCategory, opt => opt.MapFrom(src => src.CodeCategory))
                .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => src.AgeGroup))
                .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman ?? false))
                .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.LengthMinutes))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
                .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.PriceBase))
                .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.PricePerExtraViewer))
                .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.PricePerExtraView))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink));

           
            // BL ➡️ DTO (הצגת סרט)
            CreateMap<BLMovie, MovieDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src =>
                  GetDisplayName(src.CodeCategory)))
                .ForMember(dest => dest.AgeGroupName, opt => opt.MapFrom(src =>
                  GetDisplayName(src.AgeGroup)))
                .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.FinalPrice))
                .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.LengthMinutes ?? 0))
                .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman))
                .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.PriceBase ?? 0))
                .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.PricePerExtraViewer ?? 0))
                .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.PricePerExtraView ?? 0))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate ?? default))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl ?? ""))
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink ?? ""));
        }
    }
}
