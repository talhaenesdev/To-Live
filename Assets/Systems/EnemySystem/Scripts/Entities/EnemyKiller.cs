
using UnityEngine;

namespace EnemySystem.Scripts.Entities
{
    internal class EnemyKiller : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<ShootingSystem.Scripts.Entities.IDamageable>() is ShootingSystem.Scripts.Entities.IDamageable enemy)
            {
                enemy.KillThisEnemy();
            }
        }
    }
}