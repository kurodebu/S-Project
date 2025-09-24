using UnityEngine;
using UnityEngine.UI;
public class MateriTampil : MonoBehaviour
{
    public string materiPlanetUsed;
    public Text namaText;
    public Text materiText;
    public GameObject materiObject;
    public CameraFokus cf;
    public void TampilkanMateriurutan()
    {
        materiText.text = materiPlanetUsed;
        materiObject.SetActive(true);
    }
    public void CloseButtonMateri()
    {
        materiObject.SetActive(false);
        cf.ResetCamera();
        cf.ResetPositionRotationIfNeeded();
    }
}
