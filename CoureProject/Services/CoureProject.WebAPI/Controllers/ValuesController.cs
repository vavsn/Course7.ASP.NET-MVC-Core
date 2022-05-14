using CoureProject.Domain;
using CoureProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoureProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository<Consolidated_Weather> _weathers;
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(IRepository<Consolidated_Weather> weathers, ILogger<ValuesController> logger)
        {
            _weathers = weathers;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var weathers = _weathers.GetAll();
            return Ok(weathers);
        }
    }
}
