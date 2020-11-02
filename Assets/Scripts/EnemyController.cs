using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public sealed class EnemyController : IUpdatable
{

    #region Constants

    private const float DISTANSE_ERROR = 0.05f;
    private const float RAYCAST_Y_OFFSET = 0.5f;

    #endregion


    #region Properties

    public Transform EnemyTransform
    {
        get
        {
            return _enemyPrototypeModel.EnemyPrototypeStruct.EnemyPrototype.transform;
        }
    }

    #endregion


    #region Fields

    private EnemyPrototypeModel _enemyPrototypeModel;
    private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _targetPosition;
    Mask mask;

    #endregion


    #region Constructor

    public EnemyController(EnemyPrototypeModel enemyPrototypeModel)
    {
        _enemyPrototypeModel = enemyPrototypeModel;
        _player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = enemyPrototypeModel.EnemyPrototypeStruct.EnemyPrototype.GetComponent<NavMeshAgent>();
    }

    #endregion


    #region Methods

    public void UpdateTick()
    {
        EnemyAction();
    }

    private void EnemyAction()
    {
        Vector3 directionToPlayer = _player.transform.position - EnemyTransform.position;

        if (IsPlayerInVision(directionToPlayer))
        {
            LookAtPlayer();
            GoToPlayer();
        }
    }

    private void GoToPlayer()
    {
        if (Mathf.Abs(_targetPosition.sqrMagnitude - _player.transform.position.sqrMagnitude) > DISTANSE_ERROR)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
            _targetPosition = _player.transform.position;
        }
    }

    private void LookAtPlayer()
    {
        EnemyTransform.LookAt(new Vector3(_player.transform.position.x, EnemyTransform.position.y, _player.transform.position.z));
    }

    private bool IsPlayerInVision(Vector3 directionToPlayer)
    {
        EnemyPrototypeStruct enemyPrototypeStruct = _enemyPrototypeModel.EnemyPrototypeStruct;

        if (enemyPrototypeStruct.VisionAngle < Vector3.Angle(directionToPlayer, EnemyTransform.forward))
            return false;

        
        RaycastHit hit;
        Vector3 offsetPosition = new Vector3(EnemyTransform.position.x, EnemyTransform.position.y + RAYCAST_Y_OFFSET, EnemyTransform.position.z);
        var rayCast = Physics.Raycast(offsetPosition, directionToPlayer, out hit, enemyPrototypeStruct.VisionRange, enemyPrototypeStruct.LayerMask);
        if (!rayCast)
            return false;
        if (!hit.collider.gameObject.CompareTag("Player"))
            return false;

        return true;
    }

    #endregion

}

