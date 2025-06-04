using System.Reflection;
using AutoMapper;
using BL.Models;
using DAL.Models;
using iText.Svg.Renderers.Path.Impl;

namespace BL.Profiles
{
    public class MovieProfile : Profile
    {
       
        public MovieProfile()
        {
            CreateMap<Movie, BLMovie>()
          .ForMember(dest => dest.CodeCategory, opt => opt.MapFrom(src => src.CategoryCode ?? 0))
          .ForMember(dest => dest.AgeGroup, opt => opt.MapFrom(src => src.AgeCode ?? 0))
          .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.ThereIsWoman ?? false))
          .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.Length))
          .ForMember(dest => dest.TotalViews, opt => opt.MapFrom(src => src.AmountOfViews ?? 0))
          .ForMember(dest => dest.TotalViewers, opt => opt.MapFrom(src => src.OrderItems.Sum(o => o.ViewerCount)))
          .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.FilmProductionDate))
          .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.BasePrice))
          .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.ExtraViewerPrice))
          .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.ExtraViewPrice))
          .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.Link))
          .ForMember(dest => dest.CodeCategoryNavigation, opt => opt.MapFrom(src => src.CategoryCodeNavigation))
          .ForMember(dest => dest.AgeGroupNavigation, opt => opt.MapFrom(src => src.AgeCodeNavigation));

            // BL → DAL
            CreateMap<BLMovie, Movie>()
                .ForMember(dest => dest.CategoryCode, opt => opt.MapFrom(src => src.CodeCategory))
                .ForMember(dest => dest.AgeCode, opt => opt.MapFrom(src => src.AgeGroup))
                .ForMember(dest => dest.ThereIsWoman, opt => opt.MapFrom(src => src.HasWoman))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.LengthMinutes))
                .ForMember(dest => dest.AmountOfViews, opt => opt.MapFrom(src => src.TotalViews))
                .ForMember(dest => dest.FilmProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
                .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.PriceBase))
                .ForMember(dest => dest.ExtraViewerPrice, opt => opt.MapFrom(src => src.PricePerExtraViewer))
                .ForMember(dest => dest.ExtraViewPrice, opt => opt.MapFrom(src => src.PricePerExtraView))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.MovieLink))
                .ForMember(dest => dest.CategoryCodeNavigation, opt => opt.MapFrom(src => src.CodeCategoryNavigation))
                .ForMember(dest => dest.AgeCodeNavigation, opt => opt.MapFrom(src => src.AgeGroupNavigation));


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
                .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink));

            // DTO ➡️ BL (עדכון סרט קיים)
            CreateMap<MovieUpdateDTO, BLMovie>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // חייב להתעדכן תמיד
                 .ForMember(dest => dest.Name, opt => {
                     opt.PreCondition(src => !string.IsNullOrEmpty(src.Name));
                     opt.MapFrom(src => src.Name);
                 })
                 .ForMember(dest => dest.Description, opt => {
                     opt.PreCondition(src => !string.IsNullOrEmpty(src.Description));
                     opt.MapFrom(src => src.Description);
                 })
                 .ForMember(dest => dest.CodeCategory, opt => {
                     opt.PreCondition(src => src.CodeCategory != null);
                     opt.MapFrom(src => src.CodeCategory.Value);
                 })
                 .ForMember(dest => dest.AgeGroup, opt => {
                     opt.PreCondition(src => src.AgeGroup != null);
                     opt.MapFrom(src => src.AgeGroup.Value);
                 })
                 .ForMember(dest => dest.HasWoman, opt => {
                     opt.PreCondition(src => src.HasWoman != null);
                     opt.MapFrom(src => src.HasWoman.Value);
                 })
                 .ForMember(dest => dest.LengthMinutes, opt => {
                     opt.PreCondition(src => src.LengthMinutes != null);
                     opt.MapFrom(src => src.LengthMinutes.Value);
                 })
                 .ForMember(dest => dest.ProductionDate, opt => {
                     opt.PreCondition(src => src.ProductionDate != null);
                     opt.MapFrom(src => src.ProductionDate.Value);
                 })
                 .ForMember(dest => dest.PriceBase, opt => {
                     opt.PreCondition(src => src.PriceBase != null);
                     opt.MapFrom(src => src.PriceBase.Value);
                 })
                 .ForMember(dest => dest.PricePerExtraViewer, opt => {
                     opt.PreCondition(src => src.PricePerExtraViewer != null);
                     opt.MapFrom(src => src.PricePerExtraViewer.Value);
                 })
                 .ForMember(dest => dest.PricePerExtraView, opt => {
                     opt.PreCondition(src => src.PricePerExtraView != null);
                     opt.MapFrom(src => src.PricePerExtraView.Value);
                 })
                 .ForMember(dest => dest.MovieLink, opt => {
                     opt.PreCondition(src => !string.IsNullOrEmpty(src.MovieLink));
                     opt.MapFrom(src => src.MovieLink);
                 })
                 .ForMember(dest => dest.TotalViews, opt => opt.Ignore())
                 .ForMember(dest => dest.TotalViewers, opt => opt.Ignore());
            CreateMap<BLMovie, MovieGetDTO>()
    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src =>
        src.CodeCategoryNavigation != null ? src.CodeCategoryNavigation.CategoryDescription : ""))
    .ForMember(dest => dest.AgeGroupName, opt => opt.MapFrom(src =>
        src.AgeGroupNavigation != null ? src.AgeGroupNavigation.AgeDescription : ""))
    .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.FinalPrice))
    .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => src.LengthMinutes ?? 0))
    .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman))
    .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => src.PriceBase ?? 0))
    .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => src.PricePerExtraViewer ?? 0))
    .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => src.PricePerExtraView ?? 0))
    .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate ?? default))
    .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink ?? ""))
    .ForMember(dest => dest.TotalViews, opt => opt.MapFrom(src => src.TotalViews))
    .ForMember(dest => dest.TotalViewers, opt => opt.MapFrom(src => src.TotalViewers))
    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            //BL ➡️ DTO(הצגת סרט)
            CreateMap<MovieGetDTO, BLMovie>()
    .ForMember(dest => dest.CodeCategoryNavigation, opt => opt.Ignore()) // ישירות לא ממפים נוויגציה מורכבת
    .ForMember(dest => dest.AgeGroupNavigation, opt => opt.Ignore())      // ישירות לא ממפים נוויגציה מורכבת
    .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.FinalPrice))
    .ForMember(dest => dest.LengthMinutes, opt => opt.MapFrom(src => (int?)src.LengthMinutes)) // ממיר ל־nullable אם צריך
    .ForMember(dest => dest.HasWoman, opt => opt.MapFrom(src => src.HasWoman))
    .ForMember(dest => dest.PriceBase, opt => opt.MapFrom(src => (decimal?)src.PriceBase))
    .ForMember(dest => dest.PricePerExtraViewer, opt => opt.MapFrom(src => (decimal?)src.PricePerExtraViewer))
    .ForMember(dest => dest.PricePerExtraView, opt => opt.MapFrom(src => (decimal?)src.PricePerExtraView))
    .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate))
    .ForMember(dest => dest.MovieLink, opt => opt.MapFrom(src => src.MovieLink))
    .ForMember(dest => dest.TotalViews, opt => opt.MapFrom(src => src.TotalViews))
    .ForMember(dest => dest.TotalViewers, opt => opt.MapFrom(src => src.TotalViewers))
    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

        }
    }
}
