using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristGuide.API.Data;

namespace TouristGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private TouristGuideContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TouristGuideContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var persons = await _context.Persons.ToListAsync();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValueById(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);

            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var persons = await _context.Cities.ToListAsync();

            return Ok(persons);
        }
    }
}
