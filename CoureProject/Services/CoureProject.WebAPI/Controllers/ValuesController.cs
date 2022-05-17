using CoureProject.Domain;
using CoureProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoureProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        private readonly IRepositoryAsync<Consolidated_Weather> _weathers;
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(IRepositoryAsync<Consolidated_Weather> weathers, ILogger<ValuesController> logger)
        {
            _weathers = weathers;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _weathers.GetAllAsync().ConfigureAwait(true);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var weather = await _weathers.GetByIdAsync(id);
            if (weather is null)
            {
                return NotFound();
            }
            return Ok(weather);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _weathers.CountAsync().ConfigureAwait(true);
            return Ok(result);
        }
    }
}
