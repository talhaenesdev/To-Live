using System;
using PoolSystems.Scripts;
using UnityEngine;

namespace EndlessRoadSystem.Scripts.Entities
{
    public class RoadEntity : MonoBehaviour, IPoolable
    {
        [SerializeField] private RoadColliders colliders;

        public event Action<RoadEntity> PlayerEntered;

        public void OnSpawn()
        {
            colliders.PlayerEntered += OnPlayerEntered;
        }

        public void OnDespawn()
        {
            colliders.PlayerEntered -= OnPlayerEntered;
        }

        private void OnPlayerEntered()
        {
            PlayerEntered?.Invoke(this);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}