using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool IsPause { get; private set; }

    [SerializeField] private UIDisplayController _uiDisplayController;


    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var playerHealth = player.GetComponent<HealthController>();
        playerHealth.OnDie += PlayerHealth_OnDie;
    }

    private void PlayerHealth_OnDie()
    {
        print("игра окончена");
        _uiDisplayController.ShowRestart();
        Time.timeScale = 0;
        IsPause = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        IsPause = false;
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
