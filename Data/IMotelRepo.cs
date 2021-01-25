using System.Collections.Generic;
using Motel.Models;

namespace Motel.Data
{
    public interface IMotelRepo
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
    }
}