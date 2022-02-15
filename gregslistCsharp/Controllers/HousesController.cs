using gregslistCsharp.Models;
using gregslistCsharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistCsharp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _cs;
        public HousesController(HousesService cs)
        {
            _cs = cs;
        }

        // NOTE GET ALL
        [HttpGet]
        public ActionResult<List<House>> getAll()
        {
            try
            {
                return Ok(_cs.getAll());
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE GET BY ID
        [HttpGet("{houseId}")]
        public ActionResult<House> getById(string houseId)
        {
            try
            {
                House? foundHouse = _cs.getById(houseId);
                return foundHouse;
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE CREATE
        [HttpPost]
        public ActionResult<House> create([FromBody] House newHouse)
        {
            try
            {
                return Ok(_cs.Create(newHouse));
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE EDIT
        [HttpPut("{houseId}")]
        public ActionResult<House> edit([FromBody] House editedHouse, string houseId)
        {
            try
            {
                editedHouse.Id = houseId;
                House updatedHouse = _cs.Edit(editedHouse, houseId);
                return Ok(updatedHouse);
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE DELETE
        [HttpDelete("{houseId}")]
        public ActionResult<House> delete(string houseId)
        {
            try
            {
                return Ok(_cs.Remove(houseId));
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}