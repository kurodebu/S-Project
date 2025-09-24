using UnityEngine;

public class PlanetRotationMateri : MonoBehaviour
{
    public GameObject targetObject;

    private Transform targetTransform;

    // Rotation speed in degrees per second
    public float rotationSpeed = 5f;
    public float rotationSpeedPlus = 10f;
    private float defaultRotationSpeed = 5f; // Menyimpan nilai default

    private bool isRightButtonHeld = false; // Status tombol kanan hold press
    private bool isLeftButtonHeld = false;  // Status tombol kiri hold press

    void Start()
    {
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
        else
        {
            targetTransform = this.transform;
        }
    }

    void Update()
    {
        // Update rotation speed berdasarkan status hold tombol
        if (isRightButtonHeld)
        {
            rotationSpeed = -rotationSpeedPlus;
        }
        else if (isLeftButtonHeld)
        {
            rotationSpeed = rotationSpeedPlus;
        }
        else
        {
            rotationSpeed = defaultRotationSpeed;
        }

        // Rotate to the right (clockwise around Y axis)
        targetTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // Fungsi untuk mulai hold tombol kanan
    public void KlikTombolKananDown()
    {
        isRightButtonHeld = true;
    }

    // Fungsi untuk melepaskan hold tombol kanan
    public void KlikTombolKananUp()
    {
        isRightButtonHeld = false;
    }

    // Fungsi untuk mulai hold tombol kiri
    public void KlikTombolKiriDown()
    {
        isLeftButtonHeld = true;
    }

    // Fungsi untuk melepaskan hold tombol kiri
    public void KlikTombolKiriUp()
    {
        isLeftButtonHeld = false;
    }
}
