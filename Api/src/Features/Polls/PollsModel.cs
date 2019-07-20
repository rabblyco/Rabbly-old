using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RabblyApi.Users.Models;
using RabblyApi.ScoreCards.Models;

namespace RabblyApi.Polls.Models
{
    public class Poll
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Topic { get; set; }
        public User CreatedBy { get; set; }
        public IQueryable<ScoreCard> ScoreCard { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}