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
using Microsoft.AspNetCore.Hosting;

namespace RabblyApi.Controllers
{
    [Route("auth")]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public AuthController(UserService userService, IConfiguration config, IMapper mapper, IHostingEnvironment env)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet("check")]
        [Authorize]
        public async Task<IActionResult> CheckLogin()
        {
            var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;
            if(email == null)
            {
                email = HttpContext.User.Claims.Where(c => c.Type == "email").FirstOrDefault().Value;
            }
            var user = await _userService.GetUserByEmail(email);
            
            if(user == null) return BadRequest();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userService.Login(model);

            if (user == null) return BadRequest("Unable to login");

            var token = GenerateToken(user.User);

            var loginResult = new LoginResponseDto();
            loginResult.Token = new JwtSecurityTokenHandler().WriteToken(token);
            loginResult.User = user.User;
            loginResult.CreatedDebates = user.CreatedDebates;
            loginResult.ParticipatingDebates = user.ParticipatingDebates;

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
        public async Task<ActionResult<LoginResponseDto>> ConfirmSocialLogin([FromBody] SocialLoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userService.GetUserByEmail(model.Email);

            if (user != null)
            {
                var token = GenerateToken(user.User);
                var loginResult = new LoginResponseDto();
                loginResult.Token = new JwtSecurityTokenHandler().WriteToken(token);
                loginResult.User = user.User;
                loginResult.CreatedDebates = user.CreatedDebates;
                loginResult.ParticipatingDebates = user.ParticipatingDebates;
                return Ok(loginResult);
            }
            else
            {
                bool created = await _userService.Register(model.Email);
                if(!created)
                {
                    return BadRequest("Unable to create user");
                }
                user = await _userService.GetUserByEmail(model.Email);
                var token = GenerateToken(user.User);
                var loginResult = new LoginResponseDto();
                loginResult.Token = new JwtSecurityTokenHandler().WriteToken(token);
                loginResult.User = user.User;
                return Created("/auth/social", loginResult);
            }
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("email", user.Email),
                new Claim("sub", user.Id)
            };

            var tokenSecretKey = _env.IsProduction() ? Environment.GetEnvironmentVariable("TOKEN_SECRET") : _config["Keys:TokenSecret"];

            var tokenSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecretKey));
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