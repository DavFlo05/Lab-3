using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
    public Transform player;

    public float orbitSpeed = 2f;

    void Update()
    {
        // Player to enemy
        Vector3 radial =
            transform.position - player.position;

        // Orbit direction
        Vector3 tangent =
            Vector3.Cross(
                Vector3.forward,
                radial
            ).normalized;

        // Move
        transform.position +=
            tangent *
            orbitSpeed *
            Time.deltaTime;
    }
}
