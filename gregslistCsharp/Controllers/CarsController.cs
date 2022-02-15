using gregslistCsharp.Models;
using gregslistCsharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistCsharp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;
        public CarsController(CarsService cs)
        {
            _cs = cs;
        }

        // NOTE GET ALL
        [HttpGet]
        public ActionResult<List<Car>> getAll()
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
        [HttpGet("{carId}")]
        public ActionResult<Car> getById(string carId)
        {
            try
            {
                Car? foundCar = _cs.getById(carId);
                return foundCar;
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE CREATE
        [HttpPost]
        public ActionResult<Car> create([FromBody] Car newCar)
        {
            try
            {
                return Ok(_cs.Create(newCar));
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE EDIT
        [HttpPut("{carId}")]
        public ActionResult<Car> edit([FromBody] Car editedCar, string carId)
        {
            try
            {
                editedCar.Id = carId;
                Car updatedCar = _cs.Edit(editedCar, carId);
                return Ok(updatedCar);
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // NOTE DELETE
        [HttpDelete("{carId}")]
        public ActionResult<Car> delete(string carId)
        {
            try
            {
                return Ok(_cs.Remove(carId));
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
};
