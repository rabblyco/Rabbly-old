using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabblyApi.Comments.Dtos;
using RabblyApi.Comments.Models;
using RabblyApi.Comments.Services;

namespace RabblyApi.Comments.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<ActionResult<Comment>> GetComment(string id)
        {
            var comment = await _commentService.GetComment(id);
            if (comment == null) return BadRequest();

            return comment;
        }
    }
}