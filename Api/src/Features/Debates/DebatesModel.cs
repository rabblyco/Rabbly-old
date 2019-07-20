using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RabblyApi.Comments.Models;
using RabblyApi.ScoreCards.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Debates.Models
{
    public class Debate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public IQueryable<Comment> Comments { get; set; }
        public User CreatedBy { get; set; }
        public IQueryable<ScoreCard> ScoreCards { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}