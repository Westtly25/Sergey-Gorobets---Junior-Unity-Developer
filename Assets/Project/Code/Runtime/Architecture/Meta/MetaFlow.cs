using Zenject;
using Assets.Code.Runtime.Services.Windows;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;

namespace Assets.Project.Code.Runtime.Architecture.Meta
{
    public sealed class MetaFlow : IInitializable
    {
        private readonly ISaveLoadService saveLoadService;
        private readonly IWindowsHandler windowsHandler;

        [Inject]
        public MetaFlow(ISaveLoadService saveLoadService,
                        IWindowsHandler windowsHandler)
        {
            this.saveLoadService = saveLoadService;
            this.windowsHandler = windowsHandler;
        }

        public async void Initialize()
        {
            await windowsHandler.Initialize();

            windowsHandler.Show<MenuWindow>();
        }
    }
}