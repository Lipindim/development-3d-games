using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour
{
    private const float DISTANSE_ERROR = 0.25f;

    [SerializeField] private Transform[] _patrolPoints;

    [SerializeField] private float _visionRange = 5.0f;

    private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    
    private float _waitTime = 5;
    private float _currentWaitTime;
    private float _sqrVisionRange;
    private Animator _animator;

    private Vector3 CurrentPatrolPosition
    {
        get
        {
            return _patrolPoints[_currentPatrolPoint].position;
        }
    }

    private Vector3 _targetPosition;
    private int _currentPatrolPoint;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _sqrVisionRange = _visionRange * _visionRange;
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (!IsPlayerInVision())
        {
            if (IsWaitState())
                Wait();
            else
                Patrol();
        }
    }

    private void OnAnimatorIK()
    {
        if (IsPlayerInVision())
            LookAtPlayer();
    }

    private bool IsPlayerInVision()
    {
        var sqrtMagnitude = (_player.transform.position - transform.position).sqrMagnitude;
        return sqrtMagnitude < _sqrVisionRange;
    }

    private void LookAtPlayer()
    {
        //_navMeshAgent.ResetPath();
        Vector3 playerPosition = _player.transform.position;
        Vector3 lookPosition = new Vector3(playerPosition.x, playerPosition.y + 1.0f, playerPosition.z);
        _animator.SetLookAtWeight(1);
        _animator.SetLookAtPosition(lookPosition);
        //transform.LookAt(lookPosition);
    }

    private void Patrol()
    {
        
        if (_patrolPoints == null || _patrolPoints.Length == 0)
            return;

        _animator.SetFloat("Speed", 1.0f);


        if ((_targetPosition - CurrentPatrolPosition).sqrMagnitude > DISTANSE_ERROR)
        {
            _navMeshAgent.SetDestination(CurrentPatrolPosition);
            _targetPosition = CurrentPatrolPosition;
        }

        if ((transform.position - _targetPosition).sqrMagnitude < DISTANSE_ERROR)
        {
            _currentWaitTime = _waitTime;
            _currentPatrolPoint = (_currentPatrolPoint + 1) % _patrolPoints.Length;
        }
    }

    private bool IsWaitState()
    {
        return _currentWaitTime > 0;
    }

    private void Wait()
    {
        _animator.SetFloat("Speed", 0.0f);
        _currentWaitTime -= Time.deltaTime;
    }
}
