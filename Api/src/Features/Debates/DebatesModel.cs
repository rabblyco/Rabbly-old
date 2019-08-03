using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Rabbly.Data.Models;
using RabblyApi.Comments.Models;
using RabblyApi.ScoreCards.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Debates.Models
{
    public class Debate : BaseModel
    {
        public string Topic { get; set; }
        public string Description { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string CreatedById { get; set; }
        public IEnumerable<ScoreCard> ScoreCards { get; set; }
    }
}