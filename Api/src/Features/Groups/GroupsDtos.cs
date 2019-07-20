using RabblyApi.Users.Models;

namespace RabblyApi.Groups.Dtos
{
    public class GroupCreateRequestDto
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string LogoUrl { get; set; }
        public User Creator { get; set; }
    }
}