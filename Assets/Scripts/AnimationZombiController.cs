using UnityEngine;

public class AnimationZombiController : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _previousPosition;
    private ActionState _previousState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _previousPosition = transform.position;
        _previousState = ActionState.Idle;
    }

    private void Update()
    {
        ActionState currentState = ActionState.Idle;
        var abs = (_previousPosition - transform.position).sqrMagnitude;
        if (abs > 0.001f)
        {
            currentState = ActionState.Walk;
        }

        if (_previousState != currentState)
        {
            switch (currentState)
            {
                case ActionState.Walk:
                    _animator.SetTrigger("Walk");
                    break;
                case ActionState.Idle:
                    _animator.ResetTrigger("Walk");
                    break;
                default:
                    break;
            }
        }
        _previousState = currentState;
        _previousPosition = transform.position;
    }
}
