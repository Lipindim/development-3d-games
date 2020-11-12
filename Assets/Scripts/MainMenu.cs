using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool IsPause { get; private set; }

    [SerializeField] private UIDisplayController _uiDisplayController;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        print("продолжить игру");
        Time.timeScale = 1;
        _uiDisplayController.HiddenMenu();
        IsPause = false;
    }

    public void PauseGame()
    {
        print("игру на паузе");
        Time.timeScale = 0;
        _uiDisplayController.ShowMenu();
        IsPause = true;
    }
}
