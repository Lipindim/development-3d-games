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

    private float _maxHealth;

    #endregion


    #region UnityMethods

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        HealthController healthController = player.GetComponent<HealthController>();
        _maxHealth = healthController.HealthValue;
    }

    #endregion


    #region Methods

    public void DisplayCheckPointMessage(string message, float displayTime)
    {
        _checkPointText.text = message;
        Invoke(nameof(ClearCheckPointMessage), displayTime);
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
    #endregion
}
