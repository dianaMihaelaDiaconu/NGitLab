﻿
using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab
{
    /// <summary>
    /// https://github.com/gitlabhq/gitlabhq/blob/master/doc/api/members.md
    /// </summary>
    public interface IMembersClient
    {
        IEnumerable<Membership> OfProject(string projectId);

        IEnumerable<Membership> OfNamespace(string groupId);

        Membership AddMemberToProject(string projectId, ProjectMemberCreate user);
    }
}