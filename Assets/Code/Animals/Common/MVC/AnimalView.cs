using System;
using Code.MVC;
using UnityEngine;

namespace Code.Animals
{
    public abstract class AnimalView<TModel> : View<TModel>, IAnimalView
        where TModel : AnimalModel, new()
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _tastyLabel;

        public Transform Transform => transform;
        public Rigidbody Rigidbody => _rigidbody;

        public event Action<GameObject> Collided;

        private void OnCollisionEnter(Collision collision)
        {
            Collided?.Invoke(collision.collider.transform.root.gameObject);
        }

        public void ShowTasty()
        {
            _tastyLabel.SetActive(true);
            _tastyLabel.transform.forward = Camera.main.transform.forward;
        }

        public void HideTasty() => _tastyLabel.SetActive(false);
        
        public void Remove() => Destroy(gameObject);
    }
}
