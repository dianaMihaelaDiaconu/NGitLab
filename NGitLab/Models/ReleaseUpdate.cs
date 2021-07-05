using System;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class ReleaseUpdate
    {
        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "milestones")]
        public string[] Milestones;

        [DataMember(Name = "released_at")]
        public DateTime? ReleasedAt;
    }
}
