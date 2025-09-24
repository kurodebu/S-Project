using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    public RectTransform uiElement; // Elemen UI yang ingin di-zoom
    public Slider zoomSlider; // Slider untuk mengatur 
    public GameObject zoomEnabler;
    public float minScale = 0.5f; // Batas minimum zoom
    public float maxScale = 2f; // Batas maksimum zoom

    private Vector3 originalScale;

    void Start()
    {
        // Simpan skala asli dari elemen UI
        originalScale = uiElement.localScale;
        // Set slider value to represent the original scale
        zoomSlider.value = 0; // Set to 1 for original scale
        zoomSlider.onValueChanged.AddListener(OnZoomSliderChanged);
    }

    // Fungsi untuk mengubah zoom berdasarkan slider
    private void OnZoomSliderChanged(float value)
    {
        float scale = Mathf.Lerp(minScale, maxScale, value);
        uiElement.localScale = new Vector3(scale, scale, scale);
    }

    // Fungsi untuk reset zoom
    public void ResetZoom()
    {
        uiElement.localScale = originalScale;
        zoomSlider.value = 1; // Reset slider to original scale
    }

    public void ZoomEnabler() {
        // Cek apakah zoomEnabler aktif
        if (zoomEnabler.activeSelf) {
        // Jika aktif, nonaktifkan
        zoomEnabler.SetActive(false);
         } else {
        // Jika tidak aktif, aktifkan
        zoomEnabler.SetActive(true);
        }
    }
}