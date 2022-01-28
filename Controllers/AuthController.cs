using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using PeliculasSeries.Data.Interfaces;
using PeliculasSeries.Dto;
using PeliculasSeries.Services.Interface;


namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IApiRepository _apiRepository;
        private readonly IAuthRepository _Repository;
        private readonly ITokenServices _TokenServices;       
        private readonly IMapper _Mapper;

        private readonly IMailServices _MailServices;

        public AuthController(IAuthRepository Repository, ITokenServices TokenServices, IMapper Mapper, IMailServices MailServices, IApiRepository ApiRepository)
        {
            _Repository = Repository;
            _TokenServices = TokenServices;
            _Mapper = Mapper;
            _MailServices = MailServices;
            _apiRepository = ApiRepository;

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
        [HttpGet("SendEmail")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var user = await _apiRepository.GetUserByEmailAsync(email);
            if (user == null)
                return BadRequest("El usuario no existe");

            var Token = _TokenServices.CreateToken(user);
            var HtmlContent = $"<h1>Hola {user.Name}</h1> <p>Para cambiar tu contraseña haz click en el siguiente enlace:</p> <a href='https://localhost:44308/api/auth/ChangePassword?token={Token}'>Cambiar contraseña</a>";
            await _MailServices.SendEmailAsync(email, "Cambio de contraseña", HtmlContent);
            return Ok();
        }


    }
}
