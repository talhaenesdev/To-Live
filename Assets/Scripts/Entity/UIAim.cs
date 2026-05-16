using PoolSystems.Scripts;
using ShootingSystem.Scripts.Entities;
using UnityEngine;
using UnityEngine.EventSystems;
using WeaponSystem.Scripts.Enums;

public class UIAim : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PoolManager _poolManager;
    public Camera cam;
    public Transform firePoint;

    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked at: " + eventData.position);
        Vector2 screenPos = eventData.position;

        Shoot(screenPos);
    }

    void Shoot(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 worldPoint = hit.point;

            SpawnBullet(worldPoint);
        }
    }

    void SpawnBullet(Vector3 target)
    {
        Bullet bullet =
            _poolManager.Get<Bullet>("Bullet"+BulletType.Normal.ToString());

        GunBarrel gunBarrel = FindAnyObjectByType<GunBarrel>();

        bullet.transform.position =
            gunBarrel.SpawnPoint.position;

        bullet.Init(target);
    }
}