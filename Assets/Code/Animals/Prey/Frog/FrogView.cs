using UnityEngine;

namespace Code.Animals.Prey
{
    public class FrogView : AnimalView<FrogModel>
    {
        public void Jump(Vector3 impulse)
        {
            Rigidbody.linearVelocity = Vector3.zero;
            Rigidbody.AddForce(impulse, ForceMode.VelocityChange);
        }
    }
}
