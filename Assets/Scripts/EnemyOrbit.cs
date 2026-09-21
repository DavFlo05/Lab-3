using UnityEngine;

public class EnemyOrbit : MonoBehaviour
{
    public Transform player;

    [Header("Orbit")]
    public float orbitSpeed = 2f;
    public float orbitRadius = 5f;
    public float radiusCorrection = 2f;

    [Header("Distance Speed")]
    public float minDistance = 2f;
    public float maxDistance = 8f;

    public float slowSpeed = 1f;
    public float fastSpeed = 4f;

    void Update()
    {
        // Player to enemy
        Vector3 radial = transform.position - player.position;

        Vector3 radialDirection = radial.normalized;

        // Distance
        float sqrDistance = radial.sqrMagnitude;

        float minSqrDistance = minDistance * minDistance;

        float maxSqrDistance = maxDistance * maxDistance;

        float t = (sqrDistance - minSqrDistance) / (maxSqrDistance - minSqrDistance);

        t = Mathf.Clamp01(t);

        // Speed
        float currentSpeed = Mathf.Lerp(slowSpeed,fastSpeed,t);

        // Orbit direction
        Vector3 tangent = Vector3.Cross(Vector3.forward,radialDirection).normalized;

        // Radius correction
        float distance = radial.magnitude;

        float radiusDifference = distance - orbitRadius;

        Vector3 correction = -radialDirection * radiusDifference * radiusCorrection;

        // Movement
        Vector3 movement = tangent + correction;

        movement = movement.normalized;

        // Move
        transform.position += movement * currentSpeed * orbitSpeed * Time.deltaTime;

        // Face player
        FacePlayer();
    }

    void FacePlayer()
    {
        // Enemy to player
        Vector3 direction = player.position - transform.position;

        direction = direction.normalized;

        Vector3 facing = Vector3.up;

        // Get angle
        float dot = Vector3.Dot(facing,direction);

        dot = Mathf.Clamp(dot,-1f,1f);

        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // Get rotation direction
        Vector3 cross = Vector3.Cross(facing,direction);

        if (cross.z < 0)
        {
            angle = -angle;
        }

        // Rotate
        transform.rotation =
            Quaternion.Euler(0f,0f,angle);
    }
}