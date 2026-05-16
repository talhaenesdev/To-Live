using UnityEngine;

namespace ShootingSystem.Scripts.Entities
{
    public class GunBarrel : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        internal Transform SpawnPoint => _spawnPoint;
    }

}
