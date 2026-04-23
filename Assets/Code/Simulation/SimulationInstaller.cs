using Code.MainMenu;
using Zenject;

namespace Code.Simulation
{
    public class SimulationInstaller : Installer<SimulationInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainMenuFactory>().AsSingle().NonLazy();
            Container.Bind<MainMenuManager>().AsSingle().NonLazy();
        }
    }
}