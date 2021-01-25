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
        [HttpGet("{id}", Name = "GetRoomById")]
        public async Task<ActionResult<RoomReadDto>> GetRoomById(int id)
        {
            var room = await _repository.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomReadDto>(room));
        }


        //POST api/rooms
        [HttpPost]
        public async Task<ActionResult<RoomReadDto>> CreateRoom(RoomCreateDto dto)
        {

            var room = _mapper.Map<Room>(dto);
            await _repository.CreateRoom(room);
            await _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetRoomById), new { Id = room.Id }, room);
        }

        //PUT api/rooms/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, RoomUpdateDto dto)
        {
            var room = await _repository.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, room);
            await _repository.UpdateRoom(room);
            await _repository.SaveChanges();

            return NoContent();
        }


    }
}