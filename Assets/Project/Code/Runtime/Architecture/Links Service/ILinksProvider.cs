namespace Assets.Project.Code.Runtime.Architecture.Links_Service
{
    public interface ILinksProvider
    {
        UrlData[] UrlData { get; }

        void OpenUrl(UrlService url);
    }
}