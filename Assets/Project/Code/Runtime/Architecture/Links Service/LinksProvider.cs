using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Code.Runtime.Architecture.Links_Service
{
    public sealed class LinksProvider : ILinksProvider
    {
        private readonly UrlData[] urlData;

        public UrlData[] UrlData => urlData;

        public LinksProvider()
        {
            urlData = new UrlData[4]
            {
                new UrlData(UrlService.Linkedin, "https://www.linkedin.com/in/sergey-gorobets-657a4220a/"),
                new UrlData(UrlService.GoogleDocs, "https://docs.google.com/document/d/1sTgdgmcvNtUT4Zuns1SRfUwMX2GFcfWpJYFAsYcDN_o/edit?usp=sharing"),
                new UrlData(UrlService.Telegram, "https://t.me/SergeyGorobets25"),
                new UrlData(UrlService.GitHub, "https://github.com/Westtly25"),
            };
        }

        public void OpenUrl(UrlService url)
        {
            for (int i = 0; i < urlData.Length; i++)
            {
                if (urlData[i].UrlService == url)
                {
                    Application.OpenURL(urlData[i].Url);
                    break;
                }
            }
        }
    }

    public sealed class LinksPresenter : MonoBehaviour
    {
        [Header("Components")]
        private TextMeshProUGUI titleText;
        private Button[] buttons;

        private void Awake()
        {
            titleText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Initialize()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                //buttons[i].onClick.AddListener();
            }
        }
    }
}