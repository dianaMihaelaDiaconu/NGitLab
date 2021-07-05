using System;
using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab
{
    public interface IReleaseClient
    {
        IEnumerable<Release> All { get; }

        Release this[string tagName] { get; }

        Release Create(ReleaseCreate data);

        Release Update(string tagName, ReleaseUpdate data);

        void Delete(string tagName);

        IReleaseLinkClient ReleaseLinks(string tagName);
    }
}
