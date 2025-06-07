using AutoMapper;
using BL.Models;

namespace BL.Profiles
{

        public class OrderProfile : Profile
        {
            public OrderProfile()
            {

            CreateMap<OrderCreateDTO, BLOrder>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true)) 
    .ForMember(dest => dest.TotalAmount, opt => opt.Ignore())
    .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemDTO, BLOrderItem>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                    .ForMember(dest => dest.SubTotal, opt => opt.Ignore()) // מחושב ב־DB
                     .ForMember(dest => dest.Movie, opt => opt.Ignore());
            }
        
         }
}
