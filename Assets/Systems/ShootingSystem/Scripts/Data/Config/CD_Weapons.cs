using System.Collections.Generic;
using UnityEngine;
using WeaponSystem.Scripts.Data.VOs;

namespace WeaponSystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Weapons/Weapon Data")]
    internal class CD_Weapons : ScriptableObject
    {
        public List<WeaponVO> Weapons;   
    }
}