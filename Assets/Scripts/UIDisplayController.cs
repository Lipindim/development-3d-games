using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Text _checkPointText;
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _dieText;

    private float _maxHealth;
    private float _displayTime;

    #endregion


    #region UnityMethods

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        HealthController healthController = player.GetComponent<HealthController>();
        _maxHealth = healthController.HealthValue;
    }


    private void Update()
    {
        if (_displayTime > 0)
        {
            _displayTime -= Time.deltaTime;
            if (_displayTime <= 0)
                ClearCheckPointMessage();
        }
    }

    #endregion


    #region Methods

    public void DisplayCheckPointMessage(string message, float displayTime)
    {
        _checkPointText.text = message;
        _displayTime = displayTime;
    }

    private void ClearCheckPointMessage()
    {
        _checkPointText.text = string.Empty;
    }

    public void ShowMenu()
    {
        _continueButton.SetActive(true);
        _exitButton.SetActive(true);
    }

    public void HiddenMenu()
    {
        _continueButton.SetActive(false);
        _exitButton.SetActive(false);
    }

    public void ShowRestart()
    {
        _restartButton.SetActive(true);
        _exitButton.SetActive(true);
        _dieText.SetActive(true);
    }
    #endregion
}
