using RabblyApi.Comments.Models;
using RabblyApi.Debates.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Comments.Dtos
{
    public class CommentRequestDto
    {
        public string Text { get; set; }
        public Debate Debate { get; set; }
        public User CreatedBy { get; set; }
        public Comment Parent { get; set; }
    }
}