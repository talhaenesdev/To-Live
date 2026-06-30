using ShootingSystem.Scripts.Core;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem.Scripts.Data.VOs;

namespace WeaponSystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Weapons/Bullet Data")]
    internal class CD_Bullets : ScriptableObject, IBulletsData
    {
        [SerializeField] private List<BulletVO> _bullets;
        public List<BulletVO> Bullets => _bullets;
    }
}