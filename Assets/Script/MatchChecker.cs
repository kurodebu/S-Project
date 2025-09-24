using UnityEngine;
public class MatchChecker : MonoBehaviour
{
    public SlotChecking[] emptyPlanets; // Array untuk menyimpan semua emptyplanet
    public GameObject successPopup; // Referensi ke pop-up berhasil
    public GameObject errorPopup; // Referensi ke pop-up kesalahan
    public int[] expectedValues; // Array untuk menyimpan nilai yang diharapkan

    void Start()
    {
        // Pastikan panjang expectedValues sama dengan emptyPlanets
        if (expectedValues.Length != emptyPlanets.Length)
        {
            Debug.LogError("Length of expectedValues must match the number of emptyPlanets.");
        }
    }
    public void CheckMatches()
    {
        bool allMatch = true; // Variabel untuk mengecek apakah semua nilai cocok

        for (int i = 0; i < emptyPlanets.Length; i++)
        {
            // Cek nilai yang diterima dari emptyplanet
            int receivedValue = emptyPlanets[i].GetReceivedValue();

            // Logika untuk memeriksa kecocokan nilai
            if (receivedValue != expectedValues[i]) // Bandingkan dengan nilai yang diharapkan
            {
                allMatch = false;
                break; // Keluar dari loop jika ada yang tidak cocok
            }
        }

        // Tampilkan pop-up berdasarkan hasil pemeriksaan
        if (allMatch)
        {
            ShowSuccessPopup();
        }
        else
        {
            ShowErrorPopup();
        }
    }
    private void ShowSuccessPopup()
    {
        successPopup.SetActive(true); // Tampilkan pop-up berhasil
    }
    private void ShowErrorPopup()
    {
        errorPopup.SetActive(true); // Tampilkan pop-up 
    }
    public void CloseSuccessPopup()
    {
        successPopup.SetActive(false); // Menyembunyikan pop-up berhasil
    }
    public void CloseErrorPopup()
    {
        errorPopup.SetActive(false); // Menyembunyikan pop-up kesalahan
    }
}