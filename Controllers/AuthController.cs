using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using TouristGuide.API.Data.Abstract;
using TouristGuide.API.Dtos;
using TouristGuide.API.Models;

namespace TouristGuide.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;

        public object Encoding { get; private set; }

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            if (await _authRepository.UserExists(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("UserName", "UserName already exists");
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] UserForloginDto userForloginDto)
        //{
        //    var user = await _authRepository.Login(userForloginDto.UserName, userForloginDto.Password);

        //    if (user == null)
        //        return Unauthorized();

        //    var tokenHandler = new JwtSecurityTokenHandler();


        //}
    }
}
