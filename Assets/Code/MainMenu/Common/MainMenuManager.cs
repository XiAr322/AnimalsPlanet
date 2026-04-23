namespace Code.MainMenu
{
    public class MainMenuManager
    {
        private readonly MainMenuFactory _mainMenuFactory;
        private MainMenuController _mainMenuController;
        
        public MainMenuManager(MainMenuFactory mainMenuFactory)
        {
            _mainMenuFactory = mainMenuFactory;
            CreateMainMenu();
        }

        private void CreateMainMenu()
        {
            _mainMenuController = _mainMenuFactory.CreateMainMenuController();
        }
    }
}