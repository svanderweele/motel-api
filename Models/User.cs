using System;
using System.ComponentModel.DataAnnotations;

namespace Motel.Models
{
    public class User : LoggingEntity

    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}