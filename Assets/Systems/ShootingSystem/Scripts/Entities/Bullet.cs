using PoolSystems.Scripts;
using System;
using System.Collections;
using UnityEngine;

namespace ShootingSystem.Scripts.Entities
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        [SerializeField] private GameObject _bulletModel;
        [SerializeField] private Collider _collider;
        [SerializeField] private ParticleSystem _impact;

        private float _speed;
        private Vector3 _moveDirection;

        public Action<Bullet> ReturnToPool;

        bool _isBulletMove = false;
        public void OnSpawn()
        {
            _isBulletMove = true;
            _bulletModel.SetActive(true);
            _collider.ObjectTrigger += OnBulletTrigger;
        }
        public void OnDespawn()
        {
            _collider.ObjectTrigger -= OnBulletTrigger;
        }

        private void OnBulletTrigger()
        {
            OnDespawn();
            _bulletModel.SetActive(false);
            _impact.Play();
            StartCoroutine(Delay());
            _isBulletMove = false;
            Debug.Log("Bullet OnBulletTrigger");
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(_impact.main.startLifetime.constant);
            ReturnToPool?.Invoke(this);
        }

        public void Init(Vector3 direction)
        {
            _moveDirection = direction.normalized;
            transform.forward = _moveDirection;
        }

        void Update()
        {
            if (_isBulletMove)
            {
                transform.position += _moveDirection * _speed * Time.deltaTime;
            }
        }

        internal void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}
