using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position +=
            transform.forward *
            moveSpeed *
            Time.deltaTime;
    }
}