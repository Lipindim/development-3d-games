using UnityEngine;


public class DoorController : MonoBehaviour, IActivationObject
{
    private Animator _animator;

    private bool _isOpen;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void Activate()
    {
        if (_isOpen)
        {
            _animator.ResetTrigger("Open");
            _isOpen = false;
        }
        else
        {
            _animator.SetTrigger("Open");
            _isOpen = true;
        }
    }
}
