using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RabblyApi.Users.Models;
using RabblyApi.Data.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using Rabbly.Data.Models;

namespace RabblyApi.Profiles.Models
{
    public class Profile : BaseModel
    {
        [JsonIgnore]
        public User User { get; set; }
        public string Username { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender? Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Ideology { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Countries? Country { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public States? State { get; set; }
        public string ZipCode { get; set; }
        public decimal SocialCoordinate { get; set; }
        public decimal EconomicCoordinate { get; set; }
    }
}