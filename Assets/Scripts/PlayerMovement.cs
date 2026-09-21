using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector3 position = transform.position;

        // Move on X
        position.x += input * speed * Time.deltaTime;

        // Camera bounds
        Camera cam = Camera.main;

        float halfWidth = cam.orthographicSize * cam.aspect;

        float leftBound = cam.transform.position.x - halfWidth;
        float rightBound = cam.transform.position.x + halfWidth;

        // Clamp X
        position.x = Mathf.Clamp(
            position.x,
            leftBound,
            rightBound
        );

        transform.position = position;
    }
}