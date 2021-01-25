using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motel.Models
{
    public class Booking : LoggingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        public DateTime CheckOut { get; set; }

        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }


        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}