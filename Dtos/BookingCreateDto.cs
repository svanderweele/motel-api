using System;
using System.ComponentModel.DataAnnotations;

namespace Motel.Dtos
{
    public class BookingCreateDto
    {
        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int GroupId { get; set; }

    }
}