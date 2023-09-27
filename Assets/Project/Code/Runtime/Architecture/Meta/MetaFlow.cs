using Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service;
using Zenject;

namespace Assets.Project.Code.Runtime.Architecture.Meta
{
    public sealed class MetaFlow : IInitializable
    {
        private readonly ISaveLoadService saveLoadService;

        [Inject]
        public MetaFlow(ISaveLoadService saveLoadService)
        {
            this.saveLoadService = saveLoadService;
        }

        public async void Initialize()
        {
            await saveLoadService.LoadAsync();
        }
    }
}