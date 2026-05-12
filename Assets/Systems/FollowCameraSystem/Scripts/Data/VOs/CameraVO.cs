using UnityEngine;

namespace FollowCameraSystem.Scripts.Data.VOs
{
    [System.Serializable]
    public class CameraVO
    {
        public float SmoothTime;
        public Vector3 Offset;
        public CameraVO(float smoothTime, Vector3 offset)
        {
            SmoothTime = smoothTime;
            Offset = offset;
        }
    }

}
