using System;
using Code.MVC;
using UnityEngine;
using UnityEngine.UI;

namespace Code.MainMenu
{
    public class MainMenuView : View<MainMenuModel>
    {
        public event Action LoadGame; 
        
        [SerializeField] private Button _loadGameButton;

        protected override void OnStartEvent()
        {
            base.OnStartEvent();
            _loadGameButton.onClick.AddListener(()=> LoadGame?.Invoke());
        }

        private void OnDestroy()
        {
            _loadGameButton.onClick.RemoveAllListeners();
        }
    }
}