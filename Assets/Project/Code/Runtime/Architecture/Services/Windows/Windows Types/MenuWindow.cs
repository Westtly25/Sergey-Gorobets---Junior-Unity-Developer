using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class MenuWindow : Window
    {
        [SerializeField]
        private TextMeshProUGUI title;

        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Button quiteButton;

        private IWindowsHandler windowsHandler;

        public override void Initialize()
        {
            windowsHandler = diContainer.Resolve<IWindowsHandler>();
        }

        public override void Subscribe()
        {
            playButton?.onClick.AddListener(Play);
            quiteButton?.onClick.AddListener(Quite);
        }

        public override void UnSubscribe()
        {
            playButton?.onClick.RemoveListener(Play);
            quiteButton?.onClick.RemoveListener(Quite);
        }

        private async void Play()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            await Task.Delay(TimeSpan.FromSeconds(3f));
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
        }

        private void Quite() =>
            windowsHandler.ShowPopUp<QuiteWindow>();
    }
}