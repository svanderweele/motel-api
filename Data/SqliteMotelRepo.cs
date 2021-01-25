using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.Include(x => x.RoomType).ToArrayAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.Include(x => x.RoomType).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}