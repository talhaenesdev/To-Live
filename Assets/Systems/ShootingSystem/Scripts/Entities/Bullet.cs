using PoolSystems.Scripts;
using UnityEngine;

namespace ShootingSystem.Scripts.Entities
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        private float _speed = 20f;

        private Vector3 _moveDirection;
        public void OnDespawn()
        {

        }

        public void OnSpawn()
        {

        }

        public void Init(Vector3 direction)
        {
            _moveDirection = direction.normalized;
            transform.forward = _moveDirection;
        }

        void Update()
        {
            transform.position += _moveDirection * _speed * Time.deltaTime;
        }
    }
}
