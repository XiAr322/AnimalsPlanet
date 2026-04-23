using Code.MainMenu;
using Zenject;

namespace Code.DI
{
    public class MenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MainMenuInstaller.Install(Container);
        }
    }
}