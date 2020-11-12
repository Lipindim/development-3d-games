using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private bool _kill;

    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private Animator _animator;


    private void Start()
    {
        GetComponent<HealthController>().OnDie += RagdollController_OnDie;
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        _animator = GetComponent<Animator>();
        Revive();
    }

    private void RagdollController_OnDie()
    {
        Kill();
    }

    private void Update()
    {
        if (_kill)
        {
            Kill();
        }
    }

    private void Kill()
    {
        _kill = false;
        SetRagdollState(true);
        SetMainPhysics(false);
    }

    private void Revive()
    {
        SetRagdollState(false);
        SetMainPhysics(true);
    }

    private void SetRagdollState(bool activityState)
    {
        for (int i = 1; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = !activityState;
            _colliders[i].enabled = activityState;
        }
    }

    private void SetMainPhysics(bool activityState)
    {
        _animator.enabled = activityState;
        //_rigidbodies[0].isKinematic = !activityState;
        _colliders[0].enabled = activityState;
    }
}
