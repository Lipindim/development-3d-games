using System;
using UnityEngine;


public class HealthController : MonoBehaviour
{

    #region Properties

    public float HealthValue
    {
        get
        {
            return _healthValue;
        }
    }

    public float RelativeHealthValue
    {
        get
        {
            return _currentHealthValue / _maxHealthValue;
        }
    }

    #endregion


    #region Events

    public event Action<float> OnChangeHealth;
    public event Action OnDie;

    #endregion


    #region Fields

    [SerializeField] private float _healthValue = 3.0f;

    private float _currentHealthValue;
    private float _maxHealthValue;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _currentHealthValue = _healthValue;
        _maxHealthValue = _healthValue;
    }

    #endregion


    #region Methods

    public void Hurt(float damage)
    {
        _currentHealthValue -= damage;
        OnChangeHealth?.Invoke(_currentHealthValue);
        if (_currentHealthValue <= 0)
        {
            OnDie?.Invoke();
            if (!gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
    }

    #endregion Methods

}
