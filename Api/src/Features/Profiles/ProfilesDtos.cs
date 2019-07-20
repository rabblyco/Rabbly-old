using RabblyApi.Data.Utils;
using RabblyApi.Users.Models;

namespace RabblyApi.Profiles.Dtos
{
    public class ProfileEditDto
    {
        public User User { get; set; }
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Ideology { get; set; }
        public Countries Country { get; set; }
        public States? State { get; set; }
        public string ZipCode { get; set; }
        public decimal SocialCoordinate { get; set; }
        public decimal EconomicCoordinate { get; set; }
    }
}