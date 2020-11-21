using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _damageSound;

    private void Start()
    {
        GetComponent<HealthController>().OnChangeHealth += PlayerController_OnChangeHealth;
    }

    private void PlayerController_OnChangeHealth(float obj)
    {
        _damageSound.Play();
    }
}
