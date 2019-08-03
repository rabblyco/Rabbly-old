using System;
using System.Collections.Generic;
using System.Linq;
using Rabbly.Data.Models;
using RabblyApi.Debates.Models;
using RabblyApi.ScoreCards.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Comments.Models
{
    public class Comment : BaseModel
    {
        public string Text { get; set; }
        public string DebateId { get; set; }
        public User CreatedBy { get; set; }
        public Comment Parent { get; set; }
        public IQueryable<Comment> Children { get; set; }
        public IQueryable<ScoreCard> ScoreCard { get; set; }
    }
}