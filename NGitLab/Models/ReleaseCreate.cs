using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class ReleaseCreate
    {
        /// <summary>
        /// (required) - The tag where the release is created from.
        /// </summary>
        [Required]
        [DataMember(Name = "tag_name")]
        public string TagName;

        /// <summary>
        /// (optional) - The description of the release.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description;

        /// <summary>
        /// (optional) - The release name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name;

        /// <summary>
        ///  - The release name.
        /// </summary>
        [DataMember(Name = "ref")]
        public string Ref;

        [DataMember(Name = "milestones")]
        public string[] Milestones;

        [DataMember(Name = "assets")]
        public ReleaseAssetsInfo Assets;
    }
}
