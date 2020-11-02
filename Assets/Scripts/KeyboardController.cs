using UnityEngine;


public class KeyboardController : MonoBehaviour
{

    #region Fields

    //private ObjectSpawner _mineSpawner;
    //private ItemCollector _itemCollector;
    //private ItemActivator _itemActivator;
    private HealthController _playerHealthController;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _playerHealthController = GetComponent<HealthController>();
        //_mineSpawner = GetComponent<ObjectSpawner>();
        //_itemCollector = GetComponent<ItemCollector>();
        //_itemActivator = GetComponent<ItemActivator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _playerHealthController.Hurt(1);
    }

    #endregion


    #region Methods


    #endregion

}
