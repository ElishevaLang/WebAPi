using AutoMapper;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();

            CreateMap<CartDTO, Cart>();
            CreateMap<Cart, CartDTO>();

            CreateMap<OrderItemsDTO, OrderItems>();
            CreateMap<OrderItems, OrderItemsDTO>();

            CreateMap<Gift, GiftDTO>().ReverseMap();

            CreateMap<Winning, WinningDTO>().ReverseMap();

            CreateMap<Raffle, RaffleDTO>().ReverseMap();
            CreateMap<Donor, DonorDTO>().ReverseMap();
        }
    }
}
