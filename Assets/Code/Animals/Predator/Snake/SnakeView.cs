using UnityEngine;

namespace Code.Animals.Predator
{
    public class SnakeView : AnimalView<SnakeModel>
    {
        public void Move(Vector3 direction, float speed)
        {
            var currentY = Rigidbody.linearVelocity.y;
            Rigidbody.linearVelocity = new Vector3(direction.x * speed, currentY, direction.z * speed);
        }

        public void LookTowards(Vector3 direction)
        {
            Transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}
