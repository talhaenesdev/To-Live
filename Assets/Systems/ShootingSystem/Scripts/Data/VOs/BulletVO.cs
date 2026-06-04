using WeaponSystem.Scripts.Enums;

namespace WeaponSystem.Scripts.Data.VOs
{
    [System.Serializable]
    public class BulletVO
    {
        public BulletType WeaponBulletType;
        public float Speed;
        public int MagazineCapacity;
        public float Damage;
        public float MaxDistance;
    }

}
