using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Motel.Data;
using Motel.Models;

namespace Motel.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMotelRepo _repository;

        public RoomsController(IMotelRepo repository)
        {
            _repository = repository;
        }

        //GET api/rooms
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            var rooms = _repository.GetAllRooms();
            return Ok(rooms);
        }

        //GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomById(int id)
        {
            var rooms = _repository.GetRoomById(id);
            return Ok(rooms);
        }


    }
}