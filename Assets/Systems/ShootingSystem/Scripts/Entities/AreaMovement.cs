using Assets.Systems.PlayerControllerSystem.Scripts.Entities;
using UnityEngine;
using Zenject;

namespace ShootingSystem.Scripts.Entities
{
    internal class AreaMovement : MonoBehaviour
    {
        [Inject] private IPlayerConfig _playerData;

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            transform.position +=
                (transform.up * -1) *
                _playerData.PlayerData.Speed *
                Time.deltaTime;
        }
    }
}
