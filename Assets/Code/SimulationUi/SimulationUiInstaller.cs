using Zenject;

namespace Code.SimulationUi
{
    public class SimulationUiInstaller : Installer<SimulationUiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SimulationUiFactory>().AsSingle().NonLazy();
            Container.Bind<SimulationUiManager>().AsSingle().NonLazy();
        }
    }
}
