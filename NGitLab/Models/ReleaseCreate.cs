using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class ReleaseCreate
    {
        [DataMember(Name = "tag_name")]
        public string TagName;

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "ref")]
        public string Ref;

        [DataMember(Name = "milestones")]
        public string[] Milestones;

        [DataMember(Name = "assets")]
        public ReleaseAssetsInfo Assets;
    }
}
