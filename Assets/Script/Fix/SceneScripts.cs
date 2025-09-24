using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    private string MateriSelect = "MateriSelect";
    private string MenuScene = "MenuScene";
    private string Simulation3D = "Simulation3D";
    private string FaktaMenyenangkan = "FaktaMenyenangkan";
    private string PuzzleGame = "PuzzleGame";
    private string QuizScene = "QuizScene";

    public void Simulasi3DButton()
    {
        SceneManager.LoadScene(Simulation3D);
    }

    public void SwitchMenuScene()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void SwitchFakMen()
    {
        SceneManager.LoadScene(FaktaMenyenangkan);
    }
    public void SwitchMateriSelect()
    {
        SceneManager.LoadScene(MateriSelect);
    }
    public void PuzzleButton()
    {
        SceneManager.LoadScene(PuzzleGame);
    }
    public void QuizButton()
    {
        SceneManager.LoadScene(QuizScene);
    }
}
