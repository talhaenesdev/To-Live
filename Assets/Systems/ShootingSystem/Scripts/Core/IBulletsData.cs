using System.Collections.Generic;
using WeaponSystem.Scripts.Data.VOs;

namespace ShootingSystem.Scripts.Core
{
    internal interface IBulletsData
    {
        List<BulletVO> Bullets { get; }
    }
}