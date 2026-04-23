using Code.SceneLoaded;
using Zenject;

namespace Code.DI
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SceneLoaderInstaller.Install(Container);
        }
    }
}