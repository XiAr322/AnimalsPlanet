namespace Code.Animals.Predator
{
    public class SnakeModel : AnimalModel
    {
        public override AnimalRole Role => AnimalRole.Predator;

        public float Speed = 2.5f;
    }
}
