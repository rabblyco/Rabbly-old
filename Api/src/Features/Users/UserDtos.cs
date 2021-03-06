using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using RabblyApi.Debates.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Users.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(12)]
        public string Password { get; set; }

        [Required]
        [MinLength(12)]
        public string NewPassword { get; set; }
    }

    public class SocialLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class LoginRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(12)]
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public User User { get; set; }
        public IEnumerable<Debate> CreatedDebates { get; set; }
        public IEnumerable<Debate> ParticipatingDebates { get; set; }
        public string Token { get; set; }

    }

    public class UserServiceLoginResponseDto
    {
        public User User { get; set; }
        public IEnumerable<Debate> CreatedDebates { get; set; }
        public IEnumerable<Debate> ParticipatingDebates { get; set; }
    }
}