using System.Collections.Generic;
using Motel.Models;

namespace Motel.Data
{
    public class MockMotelRepo : IMotelRepo
    {
        public IEnumerable<Room> GetAllRooms()
        {
            var rooms = new List<Room> {
                new Room{Id = 1, Name = "Regular Room", RoomTypeId = 1},
                new Room{Id = 2, Name = "Family Room", RoomTypeId = 2},
                new Room{Id = 3, Name = "Suite Room", RoomTypeId = 3},
            };

            return rooms;
        }

        public Room GetRoomById(int id)
        {
            var room = new Room { Id = 0, Name = "Regular Room", RoomTypeId = 1 };
            return room;
        }
    }
}