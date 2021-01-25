using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Motel.Data;
using Motel.Dtos;
using Motel.Models;

namespace Motel.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IMapper _mapper;

        public BookingsController(IBookingRepo bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> ListBookings()
        {
            var bookings = await _bookingRepo.GetAllBookings();
            return Ok(_mapper.Map<IEnumerable<BookingReadDto>>(bookings));
        }
    }
}