using AutoMapper;
using Motel.Dtos;
using Motel.Models;

namespace Motel.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingReadDto>();
            CreateMap<Booking, BookingCreateDto>();
            CreateMap<User,UserReadDto>();
            CreateMap<Group, GroupReadDto>();
        }
    }
}