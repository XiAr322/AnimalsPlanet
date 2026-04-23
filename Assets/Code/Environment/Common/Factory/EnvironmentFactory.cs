using UnityEngine;
using Zenject;

namespace Code.Environment
{
    public class EnvironmentFactory
    {
        private const string ENVIRONMENT_PREFAB = "SimulationEnvironment";

        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public EnvironmentFactory(DiContainer container)
        {
            _container = container;
            _prefab = Resources.Load<GameObject>(ENVIRONMENT_PREFAB);
        }

        public GameObject CreateEnvironment() => _container.InstantiatePrefab(_prefab);
    }
}
