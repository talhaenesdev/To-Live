using PoolSystems.Scripts;
using ShootingSystem.Scripts.Entities;
using System;
using TMPro;
using UnityEngine;

namespace EnemySystem.Scripts.Entities
{
    internal class Obstacle : MonoBehaviour, IPoolable, IDamageable
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _health;
        [SerializeField] private MeshRenderer _glassMeshRenderer;
        [SerializeField] private Material _crackGlass;

        public Action<int> ReturnToPool;
        public Action<int,float> TakeDamage;

        private float _healthValue;
        private int _id;

        public void OnDespawn()
        {

        }

        public void OnSpawn()
        {

        }

        internal void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        internal void SetName(string name)
        {
            if (_name == null)
            {
                return;
            }
            _name.text = name;
        }

        internal void SetHealthText(float health)
        {
            _healthValue = health;
            SetHealthText(_healthValue.ToString());
        }
        internal void SetId(int id)
        {
            _id = id;
        }

        internal void CreateEnemy()
        {
            gameObject.SetActive(true);
        }

        internal void KillEnemy()
        {
            gameObject.SetActive(false);
        }

        private void SetHealthText(string health)
        {
            if (_health == null)
            {
                return;
            }
            _health.text = _healthValue.ToString();
        }

        internal void DamageModel()
        {
            _glassMeshRenderer.material = _crackGlass;
        }

        void IDamageable.TakeDamage(float damage)
        {
            TakeDamage?.Invoke(_id, damage);
        }
    }
}