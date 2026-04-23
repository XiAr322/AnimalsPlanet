using Code.SceneLoaded.Common;
using Zenject;

namespace Code.SceneLoaded
{
    public class SceneLoaderInstaller : Installer<SceneLoaderInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoadedManager>().AsSingle().NonLazy();
        }
    }
}