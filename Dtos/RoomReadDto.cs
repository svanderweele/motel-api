using Motel.Models;

namespace Motel.Dtos
{

    public class RoomReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomType RoomType { get; set; }
    }
}