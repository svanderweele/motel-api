using AutoMapper;
using Motel.Dtos;
using Motel.Models;

namespace Motel.Profiles{

    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();
        }
    }
}