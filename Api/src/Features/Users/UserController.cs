using Microsoft.AspNetCore.Mvc;
using RabblyApi.Users.Services;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Linq;
using RabblyApi.Users.Dtos;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RabblyApi.Users.Models;

namespace RabblyApi.Controllers
{
    [Route("auth")]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(UserService userService, IConfiguration config, IMapper mapper)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("check")]
        [Authorize]
        public async Task<IActionResult> CheckLogin()
        {
            var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;
            var user = await _userService.GetUser(email);
            
            if(user == null) return BadRequest();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userService.Login(model);

            if (user == null) return BadRequest("Unable to login");

            var token = GenerateToken(user);

            var loginResult = new LoginResponseDto();
            loginResult.Token = token;
            loginResult.User = user;

            return Ok(loginResult);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] LoginRegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userRegister = await _userService.Register(model);
            if (!userRegister) return BadRequest("Unable to register user");
            return Ok(userRegister);
        }

        [HttpPost("password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var passwordChanged = await _userService.ChangePassword(model);
            if (!passwordChanged) return BadRequest("Unable to update password");
            return Ok("Password Updated");
        }

        [HttpPost("social")]
        public async Task<ActionResult> ConfirmSocialLogin([FromBody] SocialLoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _userService.GetUser(model.Email);
            bool created = false;
            if(user == null)
            {
                created = await _userService.Register(model.Email);
            } 
            else 
            {
                return Ok(new {
                    msg = "lol"
                });
            }
            if(!created)
            {
                return BadRequest("Unable to add user");
            }
            return Ok("Successfully added user");
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var tokenSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Keys:TokenSecret"]));
            // create some credentials and specify the encoding algorithm
            var signingCredentials = new SigningCredentials(tokenSecret, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _config["Credentials:Issuer"],
                audience: _config["Credentials:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: signingCredentials
            );
            return token;
        }
    }
}