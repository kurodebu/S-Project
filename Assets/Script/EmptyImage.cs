using UnityEngine;

public class EmptyImage : MonoBehaviour
{
    public GameObject planetPanel;
    
    // Variabel untuk menyimpan nilai codePuzzle
    private int codePuzzle;
    public void PlanetPanel() {
        // Cek apakah planetPanel aktif
        if (planetPanel.activeSelf) {
        // Jika aktif, nonaktifkan
        planetPanel.SetActive(false);
         } else {
        // Jika tidak aktif, aktifkan
        planetPanel.SetActive(true);
        }
    }

    // Method untuk menerima nilai codePuzzle
    public void ReceiveCodePuzzle(int value)
    {
        codePuzzle = value;
        Debug.Log("CodePuzzle received: " + codePuzzle);
    }
}
