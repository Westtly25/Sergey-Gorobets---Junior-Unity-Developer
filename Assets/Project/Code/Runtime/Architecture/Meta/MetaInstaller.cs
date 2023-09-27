using Zenject;
using Assets.Code.Runtime.Services.Windows;

namespace Assets.Project.Code.Runtime.Architecture.Meta
{
    public sealed class MetaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WindowsHandler>();
        }
    }
}
