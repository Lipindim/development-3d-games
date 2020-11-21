using System;
using UnityEngine;

public class AnimationZombiController : MonoBehaviour
{
    public event Action OnAttackFinish;
    public event Action OnDamageFinish;

    private Animator _animator;

    //private Vector3 _previousPosition;
    //private ActionState _previousState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        //_previousPosition = transform.position;
        //_previousState = ActionState.Idle;
    }

    //private void Update()
    //{
    //    ActionState currentState = ActionState.Idle;
    //    var abs = (_previousPosition - transform.position).sqrMagnitude;
    //    if (abs > 0.001f)
    //    {
    //        currentState = ActionState.Walk;
    //    }

    //    if (_previousState != currentState)
    //    {
    //        switch (currentState)
    //        {
    //            case ActionState.Walk:
    //                _animator.SetFloat("Speed", 1.0f);
    //                break;
    //            case ActionState.Idle:
    //                _animator.SetFloat("Speed", 0.0f);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    _previousState = currentState;
    //    _previousPosition = transform.position;
    //}

    public void IdleAnimation()
    {
        _animator.SetFloat("speed", 0);
    }

    public void WalkAnimation()
    {
        _animator.SetFloat("speed", 1);
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("attack");
    }

    public void GetDamageAnimation()
    {
        _animator.SetTrigger("damage");
    }

    public void Kick()
    {
        OnAttackFinish?.Invoke();
    }

    public void Damage()
    {
        OnDamageFinish?.Invoke();
    }
}
