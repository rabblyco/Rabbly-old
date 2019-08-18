using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using Rabbly.Data.Models;
using RabblyApi.Groups.Models;
using RabblyApi.Permissions.Models;
using RabblyApi.Users.Models;

namespace RabblyApi.Ranks.Models
{
    public class Rank : BaseModel
    {
        public string Title { get; set; }
        public int Level { get; set; }
        // [JsonIgnore]
        // public Group Group { get; set; }

        [JsonIgnore]
        public IQueryable<User> Users { get; set; }
        // public Permission Permissions { get; set; }
    }
}