using System;
using Code.MVC;
using UnityEngine;

namespace Code.Animals
{
    public interface IAnimalController : IController
    {
        AnimalRole Role { get; }
        bool IsDead { get; }
        Transform Transform { get; }

        event Action<IAnimalController, GameObject> Collided;
        event Action<IAnimalController> Died;

        void Tick(float deltaTime);
        void Kill();
        void Eat();
    }
}
