using Code.Animals;
using Code.Environment;
using Code.SimulationUi;
using Zenject;

namespace Code.Simulation
{
    public class SimulationInstaller : Installer<SimulationInstaller>
    {
        public override void InstallBindings()
        {
            EnvironmentInstaller.Install(Container);
            SimulationUiInstaller.Install(Container);
            AnimalsInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<SimulationManager>().AsSingle().NonLazy();
        }
    }
}
