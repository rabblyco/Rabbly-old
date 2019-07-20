using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RabblyApi.Ranks.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Groups.Models
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string LogoUrl { get; set; }

        [JsonIgnore]
        public User Owner { get; set; }
        
        [JsonIgnore]
        public IQueryable<User> Users { get; set; }
        
        [JsonIgnore]
        public IEnumerable<Rank> Ranks { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
