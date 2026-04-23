using UnityEngine;

namespace Code.Animals.Prey
{
    public class FrogController : AnimalController<FrogView, FrogModel>
    {
        private float _jumpTimer;

        protected override void OnTick(float deltaTime)
        {
            _jumpTimer -= deltaTime;
            if (_jumpTimer > 0f)
                return;

            Jump();
            _jumpTimer = Model.JumpInterval;
        }

        private void Jump()
        {
            var direction = IsInsidePlayField() ? RandomPlanarDirection() : DirectionToCenter();
            var impulse = direction * Model.JumpForce + Vector3.up * (Model.JumpForce * 0.6f);
            View.Jump(impulse);
        }

        private static Vector3 RandomPlanarDirection()
        {
            var angle = Random.Range(0f, Mathf.PI * 2f);
            return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
        }
    }
}
