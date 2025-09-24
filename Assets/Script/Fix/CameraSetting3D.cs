using UnityEngine;
using UnityEngine.UI;

public class CameraSetting3D : MonoBehaviour
{
    [Tooltip("Camera to zoom")]
    public Camera targetCamera;

    [Tooltip("UI Slider controlling zoom")]
    public Slider zoomSlider;

    [Tooltip("Minimum field of view for perspective or orthographic size for orthographic")]
    public float minZoom = 15f;

    [Tooltip("Maximum field of view for perspective or orthographic size for orthographic")]
    public float maxZoom = 60f;

    private void Start()
    {
        if (targetCamera == null)
        {
            Debug.LogError("Target camera is not assigned.");
            enabled = false;
            return;
        }

        if (zoomSlider == null)
        {
            Debug.LogError("Zoom slider is not assigned.");
            enabled = false;
            return;
        }

        // Set slider limits
        zoomSlider.minValue = minZoom;
        zoomSlider.maxValue = maxZoom;

        // Initialize slider value to the current camera zoom
        if (targetCamera.orthographic)
        {
            zoomSlider.value = targetCamera.orthographicSize;
        }
        else
        {
            zoomSlider.value = targetCamera.fieldOfView;
        }

        // Subscribe to slider changes
        zoomSlider.onValueChanged.AddListener(OnZoomSliderChanged);
    }

    private void OnZoomSliderChanged(float value)
    {
        if (targetCamera.orthographic)
        {
            targetCamera.orthographicSize = +value;
        }
        else
        {
            targetCamera.fieldOfView = +value;
        }
    }

    private void OnDestroy()
    {
        if (zoomSlider != null)
        {
            zoomSlider.onValueChanged.RemoveListener(OnZoomSliderChanged);
        }
    }
}

