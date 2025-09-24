using System;
using UnityEngine;

public class CameraFokus : MonoBehaviour
{
    [Tooltip("Speed of camera movement and rotation.")]
    public float moveSpeed = 5f;

    [Tooltip("Speed of camera zoom (field of view).")]
    public float zoomSpeed = 5f;

    [Tooltip("Offset from the planet when zoomed in.")]
    public Vector3 zoomOffset = new Vector3(0f, 5f, -10f);

    [Tooltip("Default field of view of camera.")]
    public float defaultFOV;

    [Tooltip("Field of view when zoomed in.")]
    public float zoomedFOV;

    [Tooltip("Layer mask for planets to interact with.")]
    public LayerMask planetLayerMask;

    [Tooltip("Size of the camera.")]
    public float cameraSize; // Ukuran kamera yang baru
    public float cameraSizeZoom = 1f;

    private Camera cam;

    private Transform currentTarget = null;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isZoomedIn = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("Attach this script to a Camera!");
            enabled = false;
            return;
        }

        originalPosition = transform.position;
        originalRotation = transform.rotation;
        cam.fieldOfView = defaultFOV;

        // Mengatur ukuran kamera
        cam.orthographicSize = cameraSize; // Jika menggunakan kamera ortografis
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectPlanet();
        }

        if (isZoomedIn && currentTarget != null)
        {
            FollowTarget();
            ZoomIn();
        }
        else
        {
            ZoomOut();
            ResetPositionRotationIfNeeded();
        }
    }

    void TrySelectPlanet()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, planetLayerMask))
        {
            Transform newTarget = hit.transform;
            PlanetInfo pm = newTarget.GetComponent<PlanetInfo>();
            if (pm != null)
            {
                pm.UpdateMateriurutan();
            }
            currentTarget = newTarget;
            isZoomedIn = true;
        }
        // Mengatur ukuran kamera
        cam.orthographicSize = cameraSizeZoom; // Jika menggunakan kamera ortografis
    }

    public void ResetCamera()
    {
        currentTarget = null;
        isZoomedIn = false;
        cam.orthographicSize = cameraSize;
    }

    void FollowTarget()
    {
        Vector3 desiredPos = currentTarget.position + zoomOffset;
        desiredPos.x += 5f; // Menggeser kamera 5f pada sumbu X
        transform.position = Vector3.Lerp(transform.position, desiredPos, moveSpeed * Time.deltaTime);

        Vector3 direction = currentTarget.position - transform.position;
        Quaternion desiredRot = Quaternion.LookRotation(direction.normalized, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, moveSpeed * Time.deltaTime);
    }

    void ZoomIn()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomedFOV, zoomSpeed * Time.deltaTime);
    }

    void ZoomOut()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultFOV, zoomSpeed * Time.deltaTime);
        // Mengatur ukuran kamera kembali ke ukuran semula saat zoom out
        //cam.orthographicSize = cameraSize; // Jika menggunakan kamera ortografis
    }

    public void ResetPositionRotationIfNeeded()
    {
        if (transform.position != originalPosition || transform.rotation != originalRotation)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, moveSpeed * Time.deltaTime);
            //cam.orthographicSize = cameraSize; 
        }
    }
}
