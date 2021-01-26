using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motel.Models
{
    public class LoggingEntity
    {
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        public DateTime UpdatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        public DateTime? DeletedAt { get; set; }
    }
}