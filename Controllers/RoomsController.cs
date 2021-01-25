using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Motel.Data;
using Motel.Dtos;
using Motel.Models;

namespace Motel.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMotelRepo _repository;
        private readonly IMapper _mapper;

        public RoomsController(IMotelRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetRooms()
        {
            var rooms = await _repository.GetAllRooms();
            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(rooms));
        }

        //GET api/rooms/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomReadDto>> GetRoomById(int id)
        {
            var room = await _repository.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomReadDto>(room));
        }


    }
}