using Microsoft.AspNetCore.Mvc;
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
    }
}