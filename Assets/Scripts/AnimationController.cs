using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _previousPosition;
    private ActionState _previousState;
    private Quaternion _previousRotation;

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
        if (abs < 0.001f)
        {
            if (transform.rotation != _previousRotation)
                currentState = ActionState.Turn;
        }
        else
        {
            currentState = ActionState.Walk;
        }

        if (_previousState != currentState)
        {
            switch (currentState)
            {
                case ActionState.Walk:
                    {
                        _animator.SetFloat("Speed", 1);
                        _animator.SetFloat("Turn", 0);
                    }
                    break;
                case ActionState.Idle:
                    {
                        _animator.SetFloat("Speed", 0);
                        _animator.SetFloat("Turn", 0);
                    }
                    break;
                case ActionState.Turn:
                    {
                        float turn = _previousRotation.y - transform.rotation.y > 0 ? 1 : -1;
                        _animator.SetFloat("Speed", 0);
                        _animator.SetFloat("Turn", turn);
                    }
                    break;
                default:
                    break;
            }
        }
        _previousState = currentState;
        _previousRotation = transform.rotation;
        _previousPosition = transform.position;
    }
}
