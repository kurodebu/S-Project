using UnityEngine;

public class PlanetRotation2D : MonoBehaviour
{
    // The target object to orbit around
    public Transform target;
    // Orbit speed in degrees per second
    public float orbitSpeed = 30f;
    // Flag to enable or disable rotation
    public bool isRotating = true;
    void Update()
    {
        if (isRotating && target != null)
        {
            // Rotate around the target's position in 2D (around Z axis)
            // Calculate direction from target to this object
            Vector3 dir = transform.position - target.position;
            // Calculate angle to rotate this frame
            float angle = orbitSpeed * Time.deltaTime;
            // Rotate direction vector around Z axis by angle
            float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
            float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            float newX = dir.x * cos - dir.y * sin;
            float newY = dir.x * sin + dir.y * cos;
            Vector3 newDir = new Vector3(newX, newY, dir.z);
            // Set new position
            transform.position = target.position + newDir;
        }
    }
}

