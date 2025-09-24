using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [Tooltip("The object to orbit around (e.g. the Sun)")]
    public Transform sun;

    [Tooltip("Orbit speed in degrees per second")]
    public float orbitSpeed = 10;
    public float orbitSpeed1x;
    public float orbitSpeed2x;
    public float orbitSpeed3x;

    void Update()
    {
        if (sun != null)
        {
            PlanetRotationtoOrbit();
        } else {
            Debug.LogError("No sun assigned to orbit around");
        }
    }

    public void PlanetRotationtoOrbit()
    {
        // Rotate around the sun at orbitSpeed degrees per second on Y axis
        transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
    public void OrbitSpeedto1x()
    {
        orbitSpeed = orbitSpeed1x;
    }
    public void OrbitSpeedto2x()
    {
        orbitSpeed = orbitSpeed2x;
    }
    public void OrbitSpeedto3x()
    {
        orbitSpeed = orbitSpeed3x;
    }
}
