using Code.Simulation;
using Code.SimulationUi;
using Zenject;

namespace Code.DI
{
    public class SimulationSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SimulationInstaller.Install(Container);
        }
    }
}