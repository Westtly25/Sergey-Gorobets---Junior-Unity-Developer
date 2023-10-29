using Zenject;
using Assets.Code.Runtime.Services.Windows;
using Assets.Project.Code.Runtime.Architecture.Links_Service;
using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;

namespace Assets.Project.Code.Runtime.Architecture.Meta
{
    public sealed class MetaFlow : IInitializable
    {
        private readonly ISaveLoadService saveLoadService;
        private readonly IWindowsHandler windowsHandler;
        private readonly ILinksProvider linksProvider;

        [Inject]
        public MetaFlow(ISaveLoadService saveLoadService,
                        IWindowsHandler windowsHandler,
                        ILinksProvider linksProvider)
        {
            this.saveLoadService = saveLoadService;
            this.windowsHandler = windowsHandler;
            this.linksProvider = linksProvider;
        }

        public async void Initialize()
        {
            await windowsHandler.Initialize();
            await saveLoadService.LoadAsync();

            windowsHandler.Show<MenuWindow>();
        }
    }
}