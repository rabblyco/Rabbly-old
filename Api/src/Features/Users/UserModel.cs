using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RabblyApi.Groups.Models;
using RabblyApi.Profiles.Models;
using RabblyApi.Ranks.Models;

namespace RabblyApi.Users.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public Rank Rank { get; set; }
        public Profile Profile { get; set; }
        public Group Group { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}