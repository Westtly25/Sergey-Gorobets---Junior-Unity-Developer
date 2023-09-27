using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class QuiteWindow : Window
    {
        [SerializeField]
        private Button acceptButton;

        [SerializeField]
        private Button declineButton;

        private IWindowsHandler windowsHandler;

        public override void Initialize()
        {
            windowsHandler = diContainer.Resolve<IWindowsHandler>();
        }

        public override void Subscribe()
        {
            acceptButton?.onClick.AddListener(Accept);
            declineButton?.onClick.AddListener(Decline);
        }

        public override void UnSubscribe()
        {
            acceptButton?.onClick.RemoveListener(Accept);
            declineButton?.onClick.RemoveListener(Decline);
        }

        private void Accept()
        {
            Application.Quit();
        }

        private void Decline() =>
            windowsHandler.Pop();
    }
}
