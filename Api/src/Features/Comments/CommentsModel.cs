using System;
using System.Collections.Generic;
using System.Linq;
using RabblyApi.Debates.Models;
using RabblyApi.ScoreCards.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Comments.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string DebateId { get; set; }
        public User CreatedBy { get; set; }
        public Comment Parent { get; set; }
        public IQueryable<Comment> Children { get; set; }
        public IQueryable<ScoreCard> ScoreCard { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}