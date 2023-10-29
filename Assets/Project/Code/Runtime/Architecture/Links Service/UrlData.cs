using UnityEngine;

namespace Assets.Project.Code.Runtime.Architecture.Links_Service
{
    public sealed class UrlData
    {
        [SerializeField]
        private readonly UrlService urlService;
        [SerializeField]
        private readonly string url;

        public UrlService UrlService => urlService;
        public string Url => url;

        public UrlData() { }

        public UrlData(UrlService urlService, string url)
        {
            this.urlService = urlService;
            this.url = url;
        }
    }
}
