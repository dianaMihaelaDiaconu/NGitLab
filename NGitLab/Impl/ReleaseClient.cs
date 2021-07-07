using System.Collections.Generic;
using System.Net;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class ReleaseClient : IReleaseClient
    {
        private readonly API _api;
        private readonly int _projectId;
        private readonly string _releasesPath;

        public ReleaseClient(API api, int projectId)
        {
            _api = api;
            _projectId = projectId;
            var projectPath = Project.Url + "/" + projectId;
            _releasesPath = projectPath + "/releases";
        }

        public IEnumerable<Release> All  => _api.Get().GetAll<Release>(_releasesPath + "?per_page=50");

        public Release this[string tagName] => _api.Get().To<Release>($"{_releasesPath}/{WebUtility.UrlEncode(tagName)}");

        public Release Create(ReleaseCreate data) => _api.Post().With(data).To<Release>(_releasesPath);

        public Release Update(ReleaseUpdate data) => _api.Put().With(data).To<Release>($"{_releasesPath}/{WebUtility.UrlEncode(data.TagName)}");

        public void Delete(string tagName) => _api.Delete().Execute($"{_releasesPath}/{WebUtility.UrlEncode(tagName)}");

        public IReleaseLinkClient ReleaseLinks(string tagName) => new ReleaseLinkClient(_api, _releasesPath, tagName);
    }
}
