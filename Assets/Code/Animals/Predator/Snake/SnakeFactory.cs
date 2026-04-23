using UnityEngine;
using Zenject;

namespace Code.Animals.Predator
{
    public class SnakeFactory : IAnimalFactory
    {
        private const string SNAKE_PREFAB = "Snake";

        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public SnakeFactory(DiContainer container)
        {
            _container = container;
            _prefab = Resources.Load<GameObject>(SNAKE_PREFAB);
        }

        public IAnimalController Create(Vector3 position)
        {
            var view = _container.InstantiatePrefabForComponent<SnakeView>(_prefab, position, Quaternion.identity, null);
            var controller = _container.Instantiate<SnakeController>();
            controller.ApplyView(view);
            return controller;
        }
    }
}
