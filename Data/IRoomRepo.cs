using System.Collections.Generic;
using System.Threading.Tasks;
using Motel.Models;

namespace Motel.Data
{
    public interface IRoomRepo
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task CreateRoom(Room room);
        Task UpdateRoom(Room room);

        Task DeleteRoom(Room room);

        Task<IEnumerable<RoomType>> GetAllRoomTypes();
        Task<RoomType> GetRoomTypeById(int roomTypeId);
    }
}