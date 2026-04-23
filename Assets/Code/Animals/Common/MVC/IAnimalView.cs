using System;
using Code.MVC;
using UnityEngine;

namespace Code.Animals
{
    public interface IAnimalView : IView
    {
        Transform Transform { get; }
        Rigidbody Rigidbody { get; }

        event Action<GameObject> Collided;

        void ShowTasty();
        void HideTasty();
        void Remove();
    }
}
