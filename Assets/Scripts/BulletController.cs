using UnityEngine;


public class BulletController : MonoBehaviour
{

    #region Fields

    [SerializeField] private int _damage = 1;

    private GameObject _player;
    private bool _isCollisionEnter;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _isCollisionEnter = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isCollisionEnter)
            return;

        _isCollisionEnter = true;
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.Hurt(_damage);
        }
        Destroy(gameObject);
    }

    #endregion

}
