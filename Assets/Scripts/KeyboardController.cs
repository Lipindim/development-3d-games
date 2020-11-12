using UnityEngine;


public class KeyboardController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _gun;
    [SerializeField] private MainMenu _mainMenu;


    private HealthController _playerHealthController;
    private ShotController _shotController;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _playerHealthController = GetComponent<HealthController>();
        _shotController = _gun.GetComponent<ShotController>();
    }

    private void Update()
    {
        if (MainMenu.IsPause)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            _shotController.ShotToDirection(_gun.transform.forward);

        if (Input.GetKeyDown(KeyCode.Escape))
            _mainMenu.PauseGame();
    }

    #endregion


    #region Methods


    #endregion

}
