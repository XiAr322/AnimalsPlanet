namespace Code.Animals.Prey
{
    public class FrogModel : AnimalModel
    {
        public override AnimalRole Role => AnimalRole.Prey;

        public float JumpInterval = 1.2f;
        public float JumpForce = 5f;
    }
}
