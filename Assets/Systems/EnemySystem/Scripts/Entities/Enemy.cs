using PoolSystems.Scripts;
using TMPro;
using UnityEngine;

namespace EnemySystem.Scripts.Entities
{
    internal class Enemy : MonoBehaviour, IPoolable
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _health;

        private int _healthValue;


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

        internal void SetHealth(int health)
        {

            _healthValue = health;
            SetHealthText(_healthValue.ToString());
        }

        private void SetHealthText(string health)
        {
            if (_health == null)
            {
                return;
            }
            _health.text = _healthValue.ToString();
        }

    }
}