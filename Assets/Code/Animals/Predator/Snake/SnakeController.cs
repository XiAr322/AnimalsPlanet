using UnityEngine;

namespace Code.Animals.Predator
{
    public class SnakeController : AnimalController<SnakeView, SnakeModel>
    {
        private Vector3 _direction;

        protected override void OnApplyView(SnakeView view)
        {
            base.OnApplyView(view);
            _direction = RandomPlanarDirection();
        }

        protected override void OnTick(float deltaTime)
        {
            if (!IsInsidePlayField())
                _direction = DirectionToCenter();

            var currentY = View.Rigidbody.linearVelocity.y;
            View.Rigidbody.linearVelocity = new Vector3(_direction.x * Model.Speed, currentY, _direction.z * Model.Speed);
            View.Transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
        }

        private static Vector3 RandomPlanarDirection()
        {
            var angle = Random.Range(0f, Mathf.PI * 2f);
            return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
        }
    }
}
