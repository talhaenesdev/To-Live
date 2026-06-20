using PoolSystems.Scripts;
using System;
using UnityEngine;

namespace ObstacleSystem.Scripts.Entities
{
    internal class Obstacle : MonoBehaviour, IPoolable
    {

        public Action<int> ReturnToPool;
        public Action<int,float> TakeDamage;

        private int _setId;

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

        internal void SetId(int id)
        {
            _setId = id;
        }

        internal void CreateObstacle()
        {
            gameObject.SetActive(true);
        }

        internal void KillObstacle()
        {
            gameObject.SetActive(false);
        }
    }
}