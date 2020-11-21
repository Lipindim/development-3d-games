using UnityEngine;


public class KeyboardController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _gun;
    [SerializeField] private MainMenu _mainMenu;


    private HealthController _playerHealthController;
    private ShotController _shotController;
    private ActivationItemController _activationItemController;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _playerHealthController = GetComponent<HealthController>();
        _shotController = _gun.GetComponent<ShotController>();
        _activationItemController = GetComponent<ActivationItemController>();
    }

    private void Update()
    {
        if (MainMenu.IsPause)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            _shotController.Shot();

        if (Input.GetKeyDown(KeyCode.Escape))
            _mainMenu.PauseGame();

        if (Input.GetKeyDown(KeyCode.E))
            _activationItemController.Activate();

    }

    #endregion


    #region Methods


    #endregion

}
