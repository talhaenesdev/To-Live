using PoolSystems.Scripts;
using ShootingSystem.Scripts.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WeaponSystem.Scripts.Enums;
using Zenject;

namespace ShootingSystem.Scripts.Entities
{
    public class UIAim : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private IPoolManager _poolManager;
        [Inject] private IBulletsData _bulletData;

        [SerializeField] private Camera cam;
        [SerializeField] private Transform firePoint;

        [SerializeField] private List<Bullet> _bullets = new List<Bullet>();
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 screenPos = eventData.position;
            Shoot(screenPos);
        }

        void Shoot(Vector2 screenPos)
        {
            Ray ray = cam.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _bulletData.TargetLayer))
            {
                Vector3 worldPoint = hit.point;
                SpawnBullet(worldPoint);
            }
        }

        void SpawnBullet(Vector3 target)
        {
            Bullet bullet =
                _poolManager.Get<Bullet>("Bullet" + BulletType.Normal.ToString());

            GunBarrel gunBarrel = FindAnyObjectByType<GunBarrel>();

            bullet.transform.position =
                gunBarrel.SpawnPoint.position;

            bullet.ReturnToPool += ReturnBulletToPool;
            bullet.Init(target, _bulletData.Bullets[(int)BulletType.Normal].Speed, _bulletData.Bullets[(int)BulletType.Normal].MaxDistance, _bulletData.Bullets[(int)BulletType.Normal].Damage);
            bullet.OnSpawn();


            _bullets.Add(bullet);
        }

        private void ReturnBulletToPool(Bullet bullet)
        {
            bullet.ReturnToPool -= ReturnBulletToPool;
            _poolManager.Return(bullet.gameObject);
            _bullets.Remove(bullet);
        }

        private void OnDestroy()
        {
            foreach (Bullet bullet in _bullets)
            {
                if (bullet != null)
                {
                    bullet.OnDespawn();
                }
            }
        }
    }
}