using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Rabbly.Data.Models;
using RabblyApi.Groups.Models;
using RabblyApi.Profiles.Models;
using RabblyApi.Ranks.Models;
using RabblyApi.ScoreCards.Models;

namespace RabblyApi.Users.Models
{
    public class User : BaseModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        // public Rank Rank { get; set; }
        public Profile Profile { get; set; }
        // public Group Group { get; set; }
        public IEnumerable<ScoreCard> ScoreCards { get; set; }
    }
}