using System.Collections.Generic;
using Code.Animals;
using Code.SimulationUi;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Simulation
{
    public class SimulationManager : ITickable
    {
        private const float MIN_SPAWN_INTERVAL = 1f;
        private const float MAX_SPAWN_INTERVAL = 2f;
        private const float SPAWN_HEIGHT = 1f;
        private static readonly Rect SpawnArea = new(-10f, -7f, 20f, 14f);

        private readonly List<IAnimalFactory> _factories;
        private readonly SimulationUiManager _ui;

        private readonly List<IAnimalController> _animals = new();
        private readonly Dictionary<GameObject, IAnimalController> _byGameObject = new();

        private float _spawnTimer = MIN_SPAWN_INTERVAL;

        public SimulationManager(List<IAnimalFactory> factories, SimulationUiManager ui)
        {
            _factories = factories;
            _ui = ui;
        }

        public void Tick()
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0f)
            {
                Spawn();
                _spawnTimer = Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL);
            }

            for (int i = _animals.Count - 1; i >= 0; i--)
                _animals[i].Tick(Time.deltaTime);
        }

        private void Spawn()
        {
            var factory = _factories[Random.Range(0, _factories.Count)];
            var position = new Vector3(
                Random.Range(SpawnArea.xMin, SpawnArea.xMax),
                SPAWN_HEIGHT,
                Random.Range(SpawnArea.yMin, SpawnArea.yMax));

            var controller = factory.Create(position);

            _animals.Add(controller);
            _byGameObject[controller.Transform.gameObject] = controller;

            controller.Collided += OnCollided;
            controller.Died += OnDied;
        }

        private void OnCollided(IAnimalController self, GameObject otherGameObject)
        {
            if (!_byGameObject.TryGetValue(otherGameObject, out var other))
                return;

            if (self.IsDead || other.IsDead)
                return;

            if (self.Role == AnimalRole.Prey && other.Role == AnimalRole.Predator)
            {
                self.Kill();
                other.Eat();
                return;
            }

            if (self.Role == AnimalRole.Predator && other.Role == AnimalRole.Predator &&
                self.Transform.GetInstanceID() < other.Transform.GetInstanceID())
            {
                self.Kill();
                other.Eat();
            }
        }

        private void OnDied(IAnimalController controller)
        {
            controller.Collided -= OnCollided;
            controller.Died -= OnDied;

            _animals.Remove(controller);
            _byGameObject.Remove(controller.Transform.gameObject);

            if (controller.Role == AnimalRole.Prey)
                _ui.IncrementPrey();
            else
                _ui.IncrementPredators();
        }
    }
}
