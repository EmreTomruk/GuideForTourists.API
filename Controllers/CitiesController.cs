using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TouristGuide.API.Data;
using System.Linq;
using TouristGuide.API.Dtos;
using AutoMapper;
using TouristGuide.API.Models;

namespace TouristGuide.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IEntityRepository _entityRepository;
        //private TouristGuideContext _context;

        private IMapper _mapper;

        public CitiesController(IEntityRepository entityRepository, IMapper mapper/*, TouristGuideContext context*/)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            //_context = context;
        }

        public IActionResult GetAllCities()
        {
            var cities = _entityRepository.GetCities();

            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            return Ok(citiesToReturn);
        }

        [HttpPost]
        //[Route("Add")]
        public IActionResult AddCity([FromBody] City city)
        {
            _entityRepository.Add<City>(city);

            _entityRepository.SaveAll();

            return Ok(city);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _entityRepository.GetCityAndTheirPhotosById(id);

            var cityToReturn = _mapper.Map<CityForDetailDto>(city);

            //var cityForDetailDto = new CityForDetailDto
            //{
            //    Id = city.Id,
            //    Description = city.Description,
            //    Name = city.Name,
            //    Photos = city.Photos
            //};

            return Ok(cityToReturn);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetPhotosByCity(int cityId)
        {
            var photos = _entityRepository.GetPhotosByCity(cityId);

            return Ok(photos);
        }
    }
}
