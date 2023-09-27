using System;
using Zenject;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Assets.Code.Runtime.Services.Windows
{
    [Serializable]
    public sealed class WindowsHandler : IWindowsHandler
    {
        private Stack<Window> stackWindows = new(4);
        private Window lastActive;

        private readonly Window[] cachedWindows;

        [Inject]
        public WindowsHandler(Window[] windows) =>
            this.cachedWindows = windows;

        public async UniTask Initialize()
        {
            for (int i = 0; i < cachedWindows.Length; i++)
            {
                cachedWindows[i].Initialize();
                cachedWindows[i].Hide();
            }

            await UniTask.CompletedTask;
        }

        public void Show<T>() where T : Window
        {
            for (var i = 0; i < cachedWindows.Length; i++)
            {
                if (cachedWindows[i].GetType().Equals(typeof(T)))
                {
                    if (lastActive != null)
                    {
                        lastActive.Hide();
                    }
                    cachedWindows[i].Show();
                    lastActive = cachedWindows[i];
                    stackWindows.Push(lastActive);
                    break;
                }
            }
        }

        public void ShowPopUp<T>() where T : Window
        {
            for (var i = 0; i < cachedWindows.Length; i++)
            {
                if (cachedWindows[i].GetType().Equals(typeof(T)))
                {
                    cachedWindows[i].Show();
                    lastActive = cachedWindows[i];
                    stackWindows.Push(lastActive);
                    break;
                }
            }
        }

        public void Pop()
        {
            if (stackWindows.TryPop(out Window window))
            {
                window.Hide();

                if (stackWindows.TryPeek(out Window next))
                {
                    lastActive = next;
                    lastActive.Show();
                }
            }
        }
    }
}