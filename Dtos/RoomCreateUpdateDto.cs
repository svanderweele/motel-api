using System.ComponentModel.DataAnnotations;

namespace Motel.Dtos
{
    public abstract class RoomCreateUpdateDto {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string RoomTypeId { get; set; }
    }
}