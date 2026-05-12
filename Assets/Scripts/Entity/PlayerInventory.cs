using PoolSystems.Scripts;
using ShootingSystem.Scripts.Entities;
using UnityEngine;
using WeaponSystem.Scripts.Enums;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private WeaponType _hasWeapon; // Get CD_PlayerData
    [SerializeField] private Transform _hand;
    private PoolManager _poolManager;

    private void Awake()
    {
        _poolManager = PoolManager.Instance;
    }

    void Start()
    {
        Gun gun =
            _poolManager.Get<Gun>("Weapon" + _hasWeapon.ToString());

        gun.SetParent(_hand);
    }   
}
