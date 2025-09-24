using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public float speed = 5f; // Kecepatan planet
    public float semiMajorAxis = 3f; // Sumbu utama dari oval
    public float semiMinorAxis = 2f; // Sumbu minor dari oval
    public float orbitSpeed = 1f; // Kecepatan orbit

    private float angle = 0f; // Sudut untuk pergerakan oval

    void Update()
    {
        // Mengambil input dari user untuk kecepatan
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mengupdate orbit speed berdasarkan input
        orbitSpeed += verticalInput * 0.1f; // Menambah/mengurangi kecepatan

        // Menghitung posisi planet
        angle += orbitSpeed * Time.deltaTime;
        float x = semiMajorAxis * Mathf.Cos(angle);
        float y = semiMinorAxis * Mathf.Sin(angle);

        // Mengupdate posisi planet
        transform.position = new Vector3(x, y, 0);

        // Mengontrol arah berdasarkan input horizontal
        if (horizontalInput != 0)
        {
            transform.Rotate(0, 0, horizontalInput * speed * Time.deltaTime);
        }
    }
}