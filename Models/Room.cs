using System.ComponentModel.DataAnnotations;

namespace Motel.Models
{

    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}