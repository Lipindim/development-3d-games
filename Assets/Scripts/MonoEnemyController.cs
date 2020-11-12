using UnityEngine;
using UnityEngine.AI;

public class MonoEnemyController : MonoBehaviour
{
    #region Constants

    private const float DISTANSE_ERROR = 0.05f;
    private const float RAYCAST_Y_OFFSET = 0.5f;

    #endregion


    #region Fields
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _visionAngle = 45.0f;
    [SerializeField] private float _visionRange = 20.0f;
    [SerializeField] private float _attackRange = 2.0f;

    private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _targetPosition;
    private bool _isDie;
    

    #endregion


    #region Constructor

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _isDie = false;
        GetComponent<HealthController>().OnDie += MonoEnemyController_OnDie;
    }

    private void MonoEnemyController_OnDie()
    {
        _isDie = true;
        _navMeshAgent.ResetPath();
    }

    #endregion


    #region Methods

    public void Update()
    {
        EnemyAction();
    }

    private void EnemyAction()
    {
        if (_isDie)
            return;

        Vector3 directionToPlayer = _player.transform.position - transform.position;

        if (IsPlayerInAttackRange(directionToPlayer))
        {
            _player.GetComponent<HealthController>().Hurt(1.0f);
            _navMeshAgent.ResetPath();
        }

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
        transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
    }

    private bool IsPlayerInVision(Vector3 directionToPlayer)
    {
        if (_visionAngle < Vector3.Angle(directionToPlayer, transform.forward))
            return false;


        RaycastHit hit;
        Vector3 offsetPosition = new Vector3(transform.position.x, transform.position.y + RAYCAST_Y_OFFSET, transform.position.z);
        var rayCast = Physics.Raycast(offsetPosition, directionToPlayer, out hit, _visionRange, _mask);
        if (!rayCast)
            return false;
        if (!hit.collider.gameObject.CompareTag("Player"))
            return false;

        return true;
    }

    private bool IsPlayerInAttackRange(Vector3 directionToPlayer)
    {
        if (_visionAngle < Vector3.Angle(directionToPlayer, transform.forward))
            return false;


        RaycastHit hit;
        Vector3 offsetPosition = new Vector3(transform.position.x, transform.position.y + RAYCAST_Y_OFFSET, transform.position.z);
        var rayCast = Physics.Raycast(offsetPosition, directionToPlayer, out hit, _attackRange, _mask);
        if (!rayCast)
            return false;
        if (!hit.collider.gameObject.CompareTag("Player"))
            return false;

        return true;
    }

    #endregion
}
