using System;
using UnityEngine;

public class FriendsController : MonoBehaviour
{
    [SerializeField] private UIDisplayController _uiDisplayController;
    [SerializeField] private GameObject _gun;
    [SerializeField] private string _displayMessage;
    [SerializeField] private string _dialogMessage;
    
    [SerializeField] private float _displayDistanse = 10.0f;
    [SerializeField] private float _activateDistanse = 3.0f;

    private GameObject _player;
    private bool _isMessageDisplay;
    private bool _isDialogActivated;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        ShowDisplayMessage();
        ActivateDialog();
    }

    private void ActivateDialog()
    {
        if (_isDialogActivated)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            float sqrMagnitude = (transform.position - _player.transform.position).sqrMagnitude;
            if (sqrMagnitude < _activateDistanse * _activateDistanse)
            {
                _uiDisplayController.DisplayCheckPointMessage(_dialogMessage, 10.0f);
                _gun.SetActive(true);
                _isDialogActivated = true;
            }
        }
    }

    private void ShowDisplayMessage()
    {
        if (_isMessageDisplay)
            return;

        float sqrMagnitude = (transform.position - _player.transform.position).sqrMagnitude;
        if (sqrMagnitude < _displayDistanse * _displayDistanse)
        {
            _uiDisplayController.DisplayCheckPointMessage(_displayMessage, 10.0f);
            _isMessageDisplay = true;
        }
    }
}
