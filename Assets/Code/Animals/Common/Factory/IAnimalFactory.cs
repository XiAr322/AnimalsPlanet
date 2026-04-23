using UnityEngine;

namespace Code.Animals
{
    public interface IAnimalFactory
    {
        IAnimalController Create(Vector3 position);
    }
}
