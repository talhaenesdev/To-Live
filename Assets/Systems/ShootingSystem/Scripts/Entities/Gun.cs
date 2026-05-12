
using PoolSystems.Scripts;
using UnityEngine;

namespace ShootingSystem.Scripts.Entities
{
    internal class Gun : MonoBehaviour, IPoolable
    {
        public void OnDespawn()
        {

        }

        public void OnSpawn()
        {

        }
        internal void SetParent(Transform parentObjectTransform)
        {
            transform.SetParent(parentObjectTransform);
        }
    }
}
