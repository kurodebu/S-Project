using UnityEngine;

public class CameraSwitcher2D : MonoBehaviour
{
    public Camera mainCamera;
    public Camera matahariCamera;
    public Camera merkuriusCamera;
    public Camera venusCamera;
    public Camera bumiCamera;
    public Camera marsCamera;
    public Camera jupiterCamera;
    public Camera saturnusCamera;
    public Camera uranusCamera;
    public Camera neptunusCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchMainCamera()
    {
        mainCamera.gameObject.SetActive(true);
        matahariCamera.gameObject.SetActive(false);
        merkuriusCamera.gameObject.SetActive(false);
        venusCamera.gameObject.SetActive(false);
        bumiCamera.gameObject.SetActive(false);
        marsCamera.gameObject.SetActive(false);
        jupiterCamera.gameObject.SetActive(false);
        saturnusCamera.gameObject.SetActive(false);
        uranusCamera.gameObject.SetActive(false);
        neptunusCamera.gameObject.SetActive(false);
    }

    public void SwitchMatahariCamera()
    {
        mainCamera.gameObject.SetActive(false);
        matahariCamera.gameObject.SetActive(true);
    }
    public void SwitchMerkuriusCamera()
    {
        mainCamera.gameObject.SetActive(false);
        merkuriusCamera.gameObject.SetActive(true);
    }
    public void SwitchVenusCamera()
    {
        mainCamera.gameObject.SetActive(false);
        venusCamera.gameObject.SetActive(true);
    }
    public void SwitchBumiCamera()
    {
        mainCamera.gameObject.SetActive(false);
        bumiCamera.gameObject.SetActive(true);
    }
    public void SwitchMarsCamera()
    {
        mainCamera.gameObject.SetActive(false);
        marsCamera.gameObject.SetActive(true);
    }
    public void SwitchJupiterCamera()
    {
        mainCamera.gameObject.SetActive(false);
        jupiterCamera.gameObject.SetActive(true);
    }
    public void SwitchSaturnusCamera()
    {
        mainCamera.gameObject.SetActive(false);
        saturnusCamera.gameObject.SetActive(true);
    }
    public void SwitchUranusCamera()
    {
        mainCamera.gameObject.SetActive(false);
        uranusCamera.gameObject.SetActive(true);
    }
    public void SwitchNeptunusCamera()
    {
        mainCamera.gameObject.SetActive(false);
        neptunusCamera.gameObject.SetActive(true);
    }
}
