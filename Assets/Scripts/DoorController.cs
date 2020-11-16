using UnityEngine;


public class DoorController : MonoBehaviour
{
    private GameObject _player;
    private Animator _animator;

    private bool _isOpen;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((transform.position - _player.transform.position).sqrMagnitude < 9)
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
    }
}
