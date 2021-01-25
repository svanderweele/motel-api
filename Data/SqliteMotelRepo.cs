using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motel.Dtos;
using Motel.Models;

namespace Motel.Data
{
    public class SqliteMotelRepo : IMotelRepo
    {
        private MotelContext _context;

        public SqliteMotelRepo(MotelContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            if(room == null){
                throw new ArgumentNullException(nameof(room));
            }

           await _context.Rooms.AddAsync(room);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.Include(x => x.RoomType).ToArrayAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.Include(x => x.RoomType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            var result =  await _context.SaveChangesAsync();
            return result >= 0;
        }

        public Task UpdateRoom(Room room)
        {
            //Nothing
            return Task.Delay(0);
        }
    }
}