using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motel.Models;

namespace Motel.Data
{
    public class SqliteBookingRepo : IBookingRepo
    {
        private readonly MotelContext _context;

        public SqliteBookingRepo(MotelContext context)
        {
            _context = context;
        }
        public async Task CreateBooking(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }

            await _context.Bookings.AddAsync(booking);
        }

        public async Task DeleteBooking(Booking booking)
        {
            await Task.Delay(100);
            _context.Bookings.Remove(booking);
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _context.Bookings.Include(x => x.Group)
                    .ThenInclude(x => x.Users)
                    .Include(x => x.Room)
                    .ThenInclude(x => x.RoomType)
                    .ToArrayAsync();
        }
    }
}