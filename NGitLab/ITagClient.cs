using System;
using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab
{
    public interface ITagClient
    {
        Tag Create(TagCreate tag);

        void Delete(string name);

        IEnumerable<Tag> All { get; }

        [Obsolete("Starting in Gitlab 14 releases cannot be created trough tags. Use `ReleaseClient.Create` instead", false)]
        RealeaseInfo CreateRelease(string name, ReleaseCreate data);

        [Obsolete("Starting in Gitlab 14 releases cannot be updated trough tags. Use `ReleaseClient.Update` instead", false)]
        RealeaseInfo UpdateRelease(string name, ReleaseUpdate data);
    }
}
