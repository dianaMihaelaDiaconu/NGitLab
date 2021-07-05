﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Mock.Clients
{
    internal sealed class ReleaseClient : ClientBase, IReleaseClient
    {
        private readonly int _projectId;

        public ReleaseClient(ClientContext context, int projectId)
            : base(context)
        {
            _projectId = projectId;
        }

        public IEnumerable<Models.Release> All
        {
            get
            {
                using (Context.BeginOperationScope())
                {
                    var project = GetProject(_projectId, ProjectPermission.View);
                    return project.Releases.Select(r => r.ToReleaseClient());
                }
            }
        }
        
        public Models.Release this[string tagName]
        {
            get
            {
                using (Context.BeginOperationScope())
                {
                    var project = GetProject(_projectId, ProjectPermission.View);
                    var release = project.Releases.FirstOrDefault(r => r.TagName.Equals(tagName));

                    return release.ToReleaseClient();
                }
            }
        }

        public Models.Release Create(Models.ReleaseCreate data)
        {
            using (Context.BeginOperationScope())
            {
                var project = GetProject(_projectId, ProjectPermission.View);
                var release = project.Releases.Add(data.TagName, data.Name, data.Description, Context.User);
                return release.ToReleaseClient();
            }
        }

        public Models.Release Update(string tagName, ReleaseUpdate data)
        {
            using (Context.BeginOperationScope())
            {
                var project = GetProject(_projectId, ProjectPermission.View);
                var release = project.Releases.GetByTagName(tagName);
                if (release == null)
                {
                    throw new GitLabNotFoundException();
                }

                if (data.Name != null)
                {
                    release.Name = data.Name;
                }

                if (data.Description != null)
                {
                    release.Description = data.Description;
                }

                if (data.ReleasedAt.HasValue)
                {
                    release.ReleasedAt = data.ReleasedAt.Value;
                }

                return release.ToReleaseClient();
            }
        }

        public void Delete(string tagName)
        {
            using (Context.BeginOperationScope())
            {
                var project = GetProject(_projectId, ProjectPermission.View);
                var release = project.Releases.FirstOrDefault(r => r.TagName.Equals(tagName));
                if (release == null)
                    throw new GitLabNotFoundException();

                project.Releases.Remove(release);
            }
        }

        public IReleaseLinkClient ReleaseLinks(string tagName)
        {
            throw new NotImplementedException();
        }
    }
}
