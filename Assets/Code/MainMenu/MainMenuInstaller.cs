using Zenject;

namespace Code.MainMenu
{
    public class MainMenuInstaller : Installer<MainMenuInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainMenuFactory>().AsSingle().NonLazy();
            Container.Bind<MainMenuManager>().AsSingle().NonLazy();
        }
    }
}