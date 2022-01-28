using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeliculasSeries.Data.Interfaces;
using PeliculasSeries.Dto;
using PeliculasSeries.Services.Interface;


namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _Repository;
        private readonly ITokenServices _TokenServices;       
        private readonly IMapper _Mapper;

        public AuthController(IAuthRepository Repository, ITokenServices TokenServices, IMapper Mapper)
        {
            _Repository = Repository;
            _TokenServices = TokenServices;
            _Mapper = Mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            userDto.Email = userDto.Email.ToLower();

            if (await _Repository.UserExists(userDto.Email))
                return BadRequest("El usuario ya existe");

            var userToCreate = _Mapper.Map<User>(userDto);

            var createdUser = await _Repository.Register(userToCreate, userDto.Password);
            var CreateUserDto = _Mapper.Map<UserListDto>(createdUser);
            return Ok(CreateUserDto);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userFromRepo = await _Repository.Login(userLoginDto.Email, userLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();
            

            var User = _Mapper.Map<UserListDto>(userFromRepo);
            var Token = _TokenServices.CreateToken(userFromRepo);
            return Ok(new { token = Token, user = User });

        }
    }
}
