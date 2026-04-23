using Zenject;

namespace Code.Environment
{
    public class EnvironmentInstaller : Installer<EnvironmentInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EnvironmentFactory>().AsSingle().NonLazy();
            Container.Bind<EnvironmentManager>().AsSingle().NonLazy();
        }
    }
}
