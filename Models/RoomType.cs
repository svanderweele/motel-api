using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Motel.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }

}