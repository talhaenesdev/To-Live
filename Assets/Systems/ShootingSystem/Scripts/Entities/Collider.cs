using EnemySystem.Scripts.Entities;
using System;
using UnityEngine;

namespace ShootingSystem.Scripts.Entities
{
    internal class Collider : MonoBehaviour
    {
        public Action<GameObject> ObjectTrigger;
        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (other.CompareTag("CanTrigger"))
            {
                if (other.GetComponentInParent<IDamageable>() is IDamageable damageable)
                    ObjectTrigger?.Invoke(other.GetComponentInParent<Obstacle>().gameObject);
                else
                    ObjectTrigger?.Invoke(this.gameObject);
            }
        }
    }
}