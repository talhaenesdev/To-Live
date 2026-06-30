using Assets.Systems.PlayerControllerSystem.Scripts.Entities;
using UnityEngine;
using Zenject;

namespace PlayerControllerSystem.Scripts.Entities
{
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private IPlayerConfig _playerData;

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            transform.position +=
                transform.forward *
                _playerData.PlayerData.Speed *
                Time.deltaTime;
        }
    }
}