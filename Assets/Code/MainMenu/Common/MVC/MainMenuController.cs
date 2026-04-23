using Code.MVC;
using Code.SceneLoaded;
using Zenject;

namespace Code.MainMenu
{
    public class MainMenuController : Controller<MainMenuView, MainMenuModel>
    {
        [Inject] private readonly SceneLoadedManager _sceneLoadedManager;

        protected override void OnApplyView(MainMenuView view)
        {
            base.OnApplyView(view);
            view.LoadGame += OnLoadGame;
        }

        protected override void OnCloseView(MainMenuView view)
        {
            base.OnCloseView(view);
            view.LoadGame -= OnLoadGame;
        }

        private void OnLoadGame()
        {
            _sceneLoadedManager.LoadLevel();
        }
    }
}