using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
    public Transform player;

    public float orbitSpeed = 2f;
    public float orbitRadius = 5f;
    public float radiusCorrection = 2f;

    void Update()
    {
        // Player to enemy
        Vector3 radial =
            transform.position - player.position;

        Vector3 radialDirection =
            radial.normalized;

        // Orbit direction
        Vector3 tangent =
            Vector3.Cross(
                Vector3.forward,
                radialDirection
            ).normalized;

        // Radius correction
        float distance =
            radial.magnitude;

        float radiusDifference =
            distance - orbitRadius;

        Vector3 correction =
            -radialDirection *
            radiusDifference *
            radiusCorrection;

        // Combine movement
        Vector3 movement =
            tangent + correction;

        movement =
            movement.normalized;

        // Move
        transform.position +=
            movement *
            orbitSpeed *
            Time.deltaTime;
    }
}
