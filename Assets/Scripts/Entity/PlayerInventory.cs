using PoolSystems.Scripts;
using ShootingSystem.Scripts.Entities;
using UnityEngine;
using WeaponSystem.Scripts.Enums;
using Zenject;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private WeaponType _hasWeapon; // Get CD_PlayerData
    [SerializeField] private Transform _hand;
    [Inject] private IPoolManager _poolManager;

    private void Awake()
    {

    }

    void Start()
    {
        Gun gun =
            _poolManager.Get<Gun>("Weapon" + _hasWeapon.ToString());
        gun.SetPosition(_hand.position);
        gun.SetParent(_hand);
    }   
}
