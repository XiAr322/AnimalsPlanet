using Code.MVC;

namespace Code.Animals
{
    public abstract class AnimalModel : Model
    {
        public abstract AnimalRole Role { get; }
        public bool IsDead { get; set; }
    }
}
