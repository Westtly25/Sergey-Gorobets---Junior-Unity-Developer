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
            exitButton.onClick.AddListener(Exit);
        }

        public override void UnSubscribe()
        {
            restartButton.onClick.RemoveListener(Restart);
            exitButton.onClick.RemoveListener(Exit);
        }

        private void Restart()
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        }

        private void Exit()
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        }
    }
}