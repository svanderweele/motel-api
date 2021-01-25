using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Motel.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}