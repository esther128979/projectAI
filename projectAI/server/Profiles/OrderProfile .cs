using AutoMapper;
using BL.Models;
using server.Models;

namespace server.Profiles
{

        public class OrderProfile : Profile
        {
            public OrderProfile()
            {
                // יצירת הזמנה: DTO ➡️ BL
                CreateMap<OrderCreateDTO, BLOrder>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => eStatus.InProgress))
                    .ForMember(dest => dest.TotalAmount, opt => opt.Ignore()) // מחושב ב־DB
                    .ForMember(dest => dest.Token, opt => opt.Ignore());

                CreateMap<OrderItemDTO, BLOrderItem>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                    .ForMember(dest => dest.SubTotal, opt => opt.Ignore()) // מחושב ב־DB
                    .ForMember(dest => dest.Movie, opt => opt.Ignore());
            }
        
    }
}
