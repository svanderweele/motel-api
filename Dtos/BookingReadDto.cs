using System;

namespace Motel.Dtos
{
    public class BookingReadDto
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public GroupReadDto Group { get; set; }
        public RoomReadDto Room { get; set; }

    }
}