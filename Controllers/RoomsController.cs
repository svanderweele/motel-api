using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IRoomRepo _repository;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepo repository, IMapper mapper)
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
            var roomType = await _repository.GetRoomTypeById(int.Parse(dto.RoomTypeId));

            if (roomType == null)
            {
                return NotFound("Room Type was not found!");
            }

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


        //PATCH api/rooms/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialRoomUpdate(int id, JsonPatchDocument<RoomUpdateDto> patchDocument)
        {
            var roomFromRepo = await _repository.GetRoomById(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            var roomToPatch = _mapper.Map<RoomUpdateDto>(roomFromRepo);
            patchDocument.ApplyTo(roomToPatch, ModelState);

            if (!TryValidateModel(roomToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(roomToPatch, roomFromRepo);
            await _repository.UpdateRoom(roomFromRepo);
            await _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/rooms/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            var roomFromRepo = await _repository.GetRoomById(id);
            if (roomFromRepo == null)
            {
                return NotFound();
            }

            await _repository.DeleteRoom(roomFromRepo);
            await _repository.SaveChanges();
            return NoContent();
        }


    }
}