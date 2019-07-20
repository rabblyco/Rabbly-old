using RabblyApi.Users.Models;

namespace RabblyApi.Debates.Dtos
{
    public class DebateRequestDto
    {
        public string Topic { get; set; }
        public string Description { get; set; }
        public User CreatedBy { get; set; }
    }
}