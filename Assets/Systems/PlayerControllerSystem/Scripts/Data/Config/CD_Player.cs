using PlayerControllerSystem.Scripts.Data.VOs;
using UnityEngine;

namespace PlayerControllerSystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Player/Player Data")]
    internal class CD_Player : ScriptableObject
    {
        public PlayerVO PlayerData;
    }
}