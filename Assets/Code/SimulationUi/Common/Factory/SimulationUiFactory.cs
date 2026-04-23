using UnityEngine;
using Zenject;

namespace Code.SimulationUi
{
    public class SimulationUiFactory
    {
        private const string UI_PREFAB = "SimulationUiCanvas";

        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public SimulationUiFactory(DiContainer container)
        {
            _container = container;
            _prefab = Resources.Load<GameObject>(UI_PREFAB);
        }

        public SimulationUiController CreateSimulationUiController()
        {
            var view = _container.InstantiatePrefabForComponent<SimulationUiView>(_prefab);
            var controller = _container.Instantiate<SimulationUiController>();
            controller.ApplyView(view);
            return controller;
        }
    }
}
