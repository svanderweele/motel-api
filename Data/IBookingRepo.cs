using System.Collections.Generic;
using System.Threading.Tasks;
using Motel.Models;

namespace Motel.Data
{
    public interface IBookingRepo
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task CreateBooking(Booking booking);
        Task DeleteBooking(Booking booking);
    }
}