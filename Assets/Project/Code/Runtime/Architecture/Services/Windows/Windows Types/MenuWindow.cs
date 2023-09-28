using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class MenuWindow : Window, IPersistentDataListener
    {
        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Button quiteButton;

        [SerializeField]
        private TextMeshProUGUI winsText;

        [SerializeField]
        private TextMeshProUGUI losesText;

        private IWindowsHandler windowsHandler;
        private ISaveLoadService saveLoadService;

        public override void Initialize()
        {
            windowsHandler = diContainer.Resolve<IWindowsHandler>();
            saveLoadService = diContainer.Resolve<ISaveLoadService>();
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

        public void LoadData(GameData gameData)
        {
            winsText.text = gameData.WinCount.ToString();
            losesText.text = gameData.LoseCount.ToString();
        }

        public void SaveData(ref GameData gameData)
        {
        }
    }
}