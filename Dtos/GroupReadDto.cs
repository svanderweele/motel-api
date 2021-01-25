using System.Collections.Generic;
using Motel.Models;

namespace Motel.Dtos
{
    public class GroupReadDto
    {
        public int Id { get; set; }
        public IEnumerable<UserReadDto> Users { get; set; }

    }
}