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

        private Vector3 _startPosition;
        private float _damage;
        private float _speed;
        private float _maxDistanceSqr;
        private Vector3 _moveDirection;
        public Action<Bullet> ReturnToPool;
        bool _isBulletMove = false;

        void Update()
        {
            if (_isBulletMove)
            {
                transform.position += _moveDirection * _speed * Time.deltaTime;

                float distance =
                    (transform.position - _startPosition).sqrMagnitude;

                if (distance >= _maxDistanceSqr)
                {
                    OnDespawn();
                }
            }
        }

        public void OnSpawn()
        {
            _isBulletMove = true;
            _bulletModel.SetActive(true);
            _collider.ObjectTrigger += OnBulletTrigger;
            _startPosition = transform.position;
        }

        public void OnDespawn()
        {
            _collider.ObjectTrigger -= OnBulletTrigger;
            StartCoroutine(DeActiveDelay());
            DeActiveModel();
        }

        internal void Init(Vector3 direction, float speed, float maxDistance, float damage)
        {
            SetMoveDirection(direction);
            SetSpeed(speed);
            SetMaxDistance(maxDistance);
            SetDamage(damage);
        }

        private void SetDamage(float damage)
        {
            _damage = damage;
        }

        private void OnBulletTrigger(GameObject triggerObjectCollider)
        {
            IsObjectDamageable(triggerObjectCollider);
            OnDespawn();
        }

        private void IsObjectDamageable(GameObject triggerObjectCollider)
        {
            if (triggerObjectCollider.GetComponentInParent<IDamageable>()is IDamageable damageable)
            {
                damageable.TakeDamage(_damage);
            }
        }

        IEnumerator DeActiveDelay()
        {
            float fxStartLifeTime = _impact.main.startLifetime.constant;
            yield return new WaitForSeconds(fxStartLifeTime);
            ReturnToPool?.Invoke(this);
        }

        private void DeActiveModel()
        {
            _bulletModel.SetActive(false);
            _impact.Play();
            _isBulletMove = false;

        }



        private void SetMaxDistance(float maxDistance)
        {
            _maxDistanceSqr = maxDistance * maxDistance;
        }

        private void SetSpeed(float speed) => _speed = speed;

        private void SetMoveDirection(Vector3 direction)
        {
            _moveDirection = direction.normalized;
            transform.forward = _moveDirection;
        }
    }
}
