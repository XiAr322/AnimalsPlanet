using System;
using Code.MVC;
using UnityEngine;

namespace Code.Animals
{
    public abstract class AnimalController<TView, TModel> : Controller<TView, TModel>, IAnimalController
        where TView : MonoBehaviour, IAnimalView
        where TModel : AnimalModel, new()
    {
        protected static readonly Rect PlayField = new(-12f, -9f, 24f, 18f);

        private float _tastyHideAt = -1f;

        public AnimalRole Role => Model.Role;
        public bool IsDead => Model.IsDead;
        public Transform Transform => View.Transform;

        public event Action<IAnimalController, GameObject> Collided;
        public event Action<IAnimalController> Died;

        protected override void OnApplyView(TView view)
        {
            base.OnApplyView(view);
            view.Collided += OnViewCollided;
        }

        protected override void OnCloseView(TView view)
        {
            base.OnCloseView(view);
            view.Collided -= OnViewCollided;
        }

        private void OnViewCollided(GameObject other)
        {
            Collided?.Invoke(this, other);
        }

        public void Tick(float deltaTime)
        {
            OnTick(deltaTime);

            if (_tastyHideAt > 0f && Time.time >= _tastyHideAt)
            {
                View.HideTasty();
                _tastyHideAt = -1f;
            }
        }

        protected abstract void OnTick(float deltaTime);

        public void Kill()
        {
            Model.IsDead = true;
            Died?.Invoke(this);
            View.Remove();
        }

        public void Eat()
        {
            View.ShowTasty();
            _tastyHideAt = Time.time + 1f;
        }

        protected bool IsInsidePlayField()
        {
            var position = Transform.position;
            return PlayField.Contains(new Vector2(position.x, position.z));
        }

        protected Vector3 DirectionToCenter()
        {
            var position = Transform.position;
            return -new Vector3(position.x, 0f, position.z).normalized;
        }
    }
}
