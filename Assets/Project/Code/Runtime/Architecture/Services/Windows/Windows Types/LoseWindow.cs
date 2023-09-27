using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Code.Runtime.Services.Windows;

namespace Assets.Project.Code.Runtime.Architecture.Services.Windows.Windows_Types
{
    public sealed class LoseWindow : Window
    {
        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private Button exitButton;

        public override void Subscribe()
        {
            restartButton.onClick.AddListener(Restart);
            restartButton.onClick.AddListener(Restart);
        }

        public override void UnSubscribe()
        {
            restartButton.onClick.RemoveListener(Restart);
            restartButton.onClick.RemoveListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }

        private void Exite()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }

    }
}
