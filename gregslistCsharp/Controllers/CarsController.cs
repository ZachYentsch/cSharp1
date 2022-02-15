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
    }
};
