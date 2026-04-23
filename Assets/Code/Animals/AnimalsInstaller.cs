using Code.Animals.Predator;
using Code.Animals.Prey;
using Zenject;

namespace Code.Animals
{
    public class AnimalsInstaller : Installer<AnimalsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAnimalFactory>().To<FrogFactory>().AsCached();
            Container.Bind<IAnimalFactory>().To<SnakeFactory>().AsCached();
        }
    }
}
