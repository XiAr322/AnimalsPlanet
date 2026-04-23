using UnityEngine;
using Zenject;

namespace Code.Animals.Prey
{
    public class FrogFactory : IAnimalFactory
    {
        private const string FROG_PREFAB = "Frog";

        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public FrogFactory(DiContainer container)
        {
            _container = container;
            _prefab = Resources.Load<GameObject>(FROG_PREFAB);
        }

        public IAnimalController Create(Vector3 position)
        {
            var view = _container.InstantiatePrefabForComponent<FrogView>(_prefab, position, Quaternion.identity, null);
            var controller = _container.Instantiate<FrogController>();
            controller.ApplyView(view);
            return controller;
        }
    }
}
