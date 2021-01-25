using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Motel.Data;
using Motel.Models;

namespace Motel.Controllers
{
    [ApiController]
    [Route("api/types")]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomRepo _repository;

        public RoomTypesController(IRoomRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetAllRoomTypes()
        {
            var types = await _repository.GetAllRoomTypes();
            return Ok(types);
        }
    }
}