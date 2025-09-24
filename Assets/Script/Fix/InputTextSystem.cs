using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputTextSystem : MonoBehaviour
{
    public TMP_InputField Nama; // Referensi ke Input Field
    public TMP_InputField noAbsen;
    [HideInInspector]
    public string inputNama;
    [HideInInspector]
    public string inputNoAbsen;

    // Fungsi untuk mengambil data dari Input Field
    public void GetInputValue()
    {
        inputNama = Nama.text; // Mengambil teks dari Input Field
        inputNoAbsen = noAbsen.text;
        Debug.Log("Nama: " + inputNama); // Menampilkan nilai di konsol
        Debug.Log("No Absen: " + inputNoAbsen);
        
    }

    public void ResetInputField()
    {
        Nama.text = ""; // Reset the text to an empty string
        noAbsen.text = "";
        inputNama = "";
        inputNoAbsen = "";
    }
}
