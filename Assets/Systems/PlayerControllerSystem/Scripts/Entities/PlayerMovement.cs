using PlayerControllerSystem.Scripts.Data.Config;
using UnityEngine;

namespace PlayerControllerSystem.Scripts.Entities
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Config Data")]
        [SerializeField] private CD_Player _playerData;

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
