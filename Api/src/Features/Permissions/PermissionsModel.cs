using System;
using Newtonsoft.Json;
using Rabbly.Data.Models;
using RabblyApi.Ranks.Models;

namespace RabblyApi.Permissions.Models
{
    public class Permission : BaseModel
    {
        // What can they create
        public bool CanCreateRole { get; set; }
        public bool CanCreateDiscussion { get; set; }
        // What can they add
        public bool CanAddMember { get; set; }
        public bool CanAddRank { get; set; }
        // What can they edit
        public bool CanEditGroup { get; set; }
        public bool CanEditRankPermissions { get; set; }
        public bool CanEditMemberRank { get; set; }
        // What can they delete
        public bool CanRemoveMember { get; set; }
        public bool CanRemoveRank { get; set; }
        // What they can do
        public bool CanRepresentGroup { get; set; }
        public bool CanParticipateInGroupDiscussion { get; set; }
        // Metadata
        // [JsonIgnore]
        // public Rank Rank { get; set; }
    }
}
