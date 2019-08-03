using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RabblyApi.Users.Models;
using RabblyApi.ScoreCards.Models;
using Rabbly.Data.Models;

namespace RabblyApi.Polls.Models
{
    public class Poll : BaseModel
    {
        public string Topic { get; set; }
        public User CreatedBy { get; set; }
        public IQueryable<ScoreCard> ScoreCard { get; set; }
    }
}