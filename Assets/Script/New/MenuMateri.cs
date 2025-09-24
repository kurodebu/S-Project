using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMateri : MonoBehaviour
{
    public string SceneMain;
    public GameObject infoPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseInfoPanel()
    {
    infoPanel.SetActive(false);
    }

    public void SwitchSceneMain() {
        SceneManager.LoadScene(SceneMain);
    }
}
