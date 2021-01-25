using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Motel.Models;

namespace Motel.Data
{
    public class MockMotelRepo : IMotelRepo
    {
        public Task CreateRoom(Room room)
        {
            throw new System.NotImplementedException();
        }

        //Get all the rooms in the database
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            //Mock an async call
            await Task.Delay(100);
            var rooms = new List<Room> {
                new Room{Id = 1, Name = "Regular Room", RoomTypeId = 1},
                new Room{Id = 2, Name = "Family Room", RoomTypeId = 2},
                new Room{Id = 3, Name = "Suite Room", RoomTypeId = 3},
            };
            

            return rooms;
        }

        public async Task<Room> GetRoomById(int id)
        {
            //Mock an async call
            await Task.Delay(100);
            var room = new Room { Id = 0, Name = "Regular Room", RoomTypeId = 1 };
            return room;
        }

        public Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateRoom(Room room)
        {
            throw new System.NotImplementedException();
        }
    }
}