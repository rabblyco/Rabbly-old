using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RabblyApi.Api;
using RabblyApi.Controllers;
using RabblyApi.Users.Dtos;
using RabblyApi.Users.Models;
using RabblyApi.Users.Services;
using Xunit;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using RabblyApi.Data;
using Newtonsoft.Json.Linq;
using AutoMapper;

namespace RabblyApi.Tests.IntegrationTests.Controllers
{
    public class UserControllerTests : IClassFixture<CustomWebAppFactory<RabblyApi.Api.Startup>>
    {
        private readonly HttpClient _client;
        private readonly DatabaseContext _context;
        private readonly AuthController _userController;

        public UserControllerTests(CustomWebAppFactory<RabblyApi.Api.Startup> factory)
        {
            _client = factory.CreateClient();
            _context = factory.MyDbContext;
            CreateDefaultUser().Wait();
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var tokenSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("204cfd01-1466-4b60-bde6-dbdba1f9cbfe"));
            // create some credentials and specify the encoding algorithm
            var signingCredentials = new SigningCredentials(tokenSecret, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: "meh",
                audience: "meh",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: signingCredentials
            );
            return token;
        }

        private async Task<bool> CreateDefaultUser()
        {
            var register = new LoginRegisterDto();
            register.Email = "dwdewul@gmail.com";
            register.Password = "password1234";
            var service = new UserService(_context);
            return await service.Register(register);
        }

        private async Task<LoginResponseDto> GetDefaultUser()
        {
            var login = new LoginRegisterDto();
            login.Email = "dwdewul@gmail.com";
            login.Password = "password1234";
            var response = await _client.PostAsJsonAsync("/auth/login", login);
            var responseString = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(responseString);
            Console.WriteLine($"login response: {loginResponse.User.Password}");
            return loginResponse;
        }

        [Fact]
        public async Task UserController_ShouldReturnUnauthorized_WithInvalidtoken()
        {
            var response = await _client.GetAsync("/auth/check");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task UserController_ShouldNot_ReturnHashedPassword()
        {
            var loginResponse = await GetDefaultUser();
            Assert.Null(loginResponse.User.Password);
        }

        [Fact]
        public async Task UserController_ShouldReturnOk_WithValidToken()
        {
            // Arrange
            var loginResponse = await GetDefaultUser();
            Console.WriteLine($"response: {loginResponse}");
            var authorizationHeaders = new AuthenticationHeaderValue("Bearer", loginResponse.Token ?? "");
            _client.DefaultRequestHeaders.Authorization = authorizationHeaders;

            // Act
            var response = await _client.GetAsync("/auth/check");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UserController_ShouldLogin_IfUserExists()
        {
            var login = new LoginRegisterDto();
            login.Email = "dwdewul@gmail.com";
            login.Password = "password1234";

            var response = await _client.PostAsJsonAsync("/auth/login", login);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UserController_ShouldNotLogin_IfUserDoesNotExist()
        {
            var login = new LoginRegisterDto();
            login.Email = "notregistered@gmail.com";
            login.Password = "password1234";

            var response = await _client.PostAsJsonAsync("/auth/login", login);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UserService_ShouldNotCreate_DuplicateUser()
        {
            var service = new UserService(_context);
            var register = new LoginRegisterDto();
            register.Email = "dwdewul@gmail.com";
            register.Password = "password1234";
            var userWasCreated = await service.Register(register);

            Assert.Equal(false, userWasCreated);
        }

        [Fact]
        public async Task UserService_ShouldCreate_NewUser()
        {
            var service = new UserService(_context);
            var register = new LoginRegisterDto();
            register.Email = "tester@gmail.com";
            register.Password = "password1234";
            var userWasCreated = await service.Register(register);

            Assert.Equal(true, userWasCreated);
        }
    }
}