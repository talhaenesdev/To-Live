using FollowCameraSystem.Scripts.Data.Config;
using UnityEngine;


internal class CameraFollow : MonoBehaviour
{
    public Transform target;

    public CD_Camera data;

    private Vector3 velocity;

    void LateUpdate()
    {
        Vector3 targetPos =
            target.position + data.Offset;

        transform.position =
            Vector3.SmoothDamp(
                transform.position,
                targetPos,
                ref velocity,
                data.SmoothTime);
    }
}