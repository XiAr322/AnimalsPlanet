using Code.MainMenu;
using UnityEngine;
using Zenject;

namespace Code.MainMenu
{
    public class MainMenuFactory
    {
        private string MENU_PREFAB = "MainMenuCanvas";
        
        private readonly DiContainer _container;
        private GameObject _menuPrefab;

        public MainMenuFactory(DiContainer container)
        {
            _container = container;
            _menuPrefab = Resources.Load<GameObject>(MENU_PREFAB);
        }

        public MainMenuController CreateMainMenuController()
        {
            var view = _container.InstantiatePrefabForComponent<MainMenuView>(_menuPrefab);
            var controller = _container.Instantiate<MainMenuController>();
            controller.ApplyView(view);
            return controller;
        }
    }
}