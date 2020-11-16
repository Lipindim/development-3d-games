using UnityEngine;

public class RightHandIKController : MonoBehaviour
{
    [SerializeField] private Transform _rightHandPlace;

    [SerializeField] private bool _isActive = false;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnAnimatorIK()
    {
        if (_isActive)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandPlace.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandPlace.rotation);
        }
    }
}
