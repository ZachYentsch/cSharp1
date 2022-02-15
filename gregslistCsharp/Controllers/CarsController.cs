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
    }
};
