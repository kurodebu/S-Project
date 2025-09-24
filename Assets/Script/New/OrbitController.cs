using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public PlanetOrbit[] orbitObjects;
    // This method can be assigned to a UI Button's OnClick event
    public void OnOrbitSpeed1xButtonClicked()
    {
        foreach (var orbitObj in orbitObjects)
        {
            if (orbitObj != null)
            {
                orbitObj.OrbitSpeedto1x();
            }
        }
        Debug.Log("Orbit speeds set to orbitSpeed1x");
    }
    public void OnOrbitSpeed2xButtonClicked()
    {
        foreach (var orbitObj in orbitObjects)
        {
            if (orbitObj != null)
            {
                orbitObj.OrbitSpeedto2x();
            }
        }
        Debug.Log("Orbit speeds set to orbitSpeed2x");
    }
    public void OnOrbitSpeed3xButtonClicked()
    {
        foreach (var orbitObj in orbitObjects)
        {
            if (orbitObj != null)
            {
                orbitObj.OrbitSpeedto3x();
            }
        }
        Debug.Log("Orbit speeds set to orbitSpeed3x");
    }
}
