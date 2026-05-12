using UnityEngine;
using WeaponSystem.Scripts.Enums;

namespace WeaponSystem.Scripts.Data.VOs
{
    [System.Serializable]
    public class WeaponVO
    {
        public WeaponType WeaponPoolName;
        public Sprite WeaponIcon;
        public BulletType WeaponBulletType;
    }

}
