using UnityEngine;


public class BulletController : MonoBehaviour
{

    #region Fields

    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _damage = 1;

    private bool _isCollisionEnter;
    private Rigidbody _rigidBody;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _isCollisionEnter = false;
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_isCollisionEnter)
        {
            transform.position += transform.forward * Time.deltaTime * 30;
        }


        if (_isCollisionEnter && !_particleSystem.isPlaying)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("вошёл в тригер");
        if (_isCollisionEnter)
            return;

        _isCollisionEnter = true;
        _particleSystem.Play();
        

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.Hurt(_damage);
        }
    }

    #endregion

}
