using UnityEngine;
public class UIManagement : MonoBehaviour
{
    public GameObject materiButton;
    public GameObject puzzleButton;
    public GameObject quizButton;
    public GameObject nextMenuButton;
    public GameObject backMenuButton;
    private int currentMenu;
    void Start()
    {
        currentMenu = 0;
    }
    void NextMateriLogic()
    {
        if (currentMenu == 0)
        {
            materiButton.SetActive(true);
            puzzleButton.SetActive(false);
            quizButton.SetActive(false);
            nextMenuButton.SetActive(true);
            backMenuButton.SetActive(false);
        }
        if (currentMenu == 1)
        {
            materiButton.SetActive(false);
            puzzleButton.SetActive(true);
            quizButton.SetActive(false);
            nextMenuButton.SetActive(true);
            backMenuButton.SetActive(true);
        }
        if (currentMenu == 2)
        {
            materiButton.SetActive(false);
            puzzleButton.SetActive(false);
            quizButton.SetActive(true);
            nextMenuButton.SetActive(false);
            backMenuButton.SetActive(true);
        }
    }
    public void NextMenu()
    {
        if (currentMenu <= 2)
        {
            currentMenu += 1;
            NextMateriLogic();
        }
    }
    public void BackMenu()
    {
        if (currentMenu >= 0)
        {
            currentMenu -= 1;
            NextMateriLogic();
        }
    }
}
