using UnityEngine;

public class PlanetPuzzle : MonoBehaviour
{
    public string namePlanet;
    // Referensi ke EmptyPlanet
    public EmptyImage emptyImage;
    public int codePuzzle;

    // Method ini akan dipanggil saat GameObject diklik
    private void OnMouseDown()
    {
        // Panggil method untuk menghancurkan GameObject
        HapusPlanet();
    }

    void HapusPlanet()
    {
        // Kirim nilai ke EmptyPlanet
        if (emptyImage != null)
        {
            emptyImage.ReceiveCodePuzzle(codePuzzle);
        }
        // Destroy the GameObject
        Destroy(gameObject);
    }
}
