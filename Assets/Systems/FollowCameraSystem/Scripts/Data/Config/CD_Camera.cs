using UnityEngine;

namespace FollowCameraSystem.Scripts.Data.Config
{
    [CreateAssetMenu(menuName = "Camera/Camera Data")]
    internal class CD_Camera : ScriptableObject
    {
        [Header("Follow")]
        public Vector3 Offset;

        public float FollowSpeed = 5f;

        [Header("Rotation")]
        public float RotationSpeed = 10f;

        [Header("Zoom")]
        public float Fov = 60f;

        [Header("Smooth")]
        public float SmoothTime = 0.2f;

        [Header("Clamp")]
        public Vector2 XClamp;

        public Vector2 YClamp;

        [Header("Shake")]
        public float ShakeDuration;

        public float ShakeStrength;
    }
}