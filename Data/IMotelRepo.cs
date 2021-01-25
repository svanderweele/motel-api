using System.Collections.Generic;
using System.Threading.Tasks;
using Motel.Models;

namespace Motel.Data
{
    public interface IMotelRepo
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task CreateRoom(Room room);
        Task UpdateRoom(Room room);
    }
}