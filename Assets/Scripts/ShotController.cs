using UnityEngine;


public class ShotController : MonoBehaviour
{

    #region Fields

    [SerializeField] private Transform _sightPosition;
    [SerializeField] private GameObject _bloodDecal;
    [SerializeField] private GameObject _woodDecal;
    [SerializeField] private GameObject _metallDecal;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _muzzleFlashEffect;

    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _reloadTime = 1.0f;

    private bool _isReload;

    #endregion


    #region Properties

    public bool IsReload
    {
        get
        {
            return _isReload;
        }
    }

    #endregion


    #region Methods


    public void Shot()
    {
        if (!_isReload)
        {
            if (!gameObject.activeSelf)
                return;

             _isReload = true;
            Invoke(nameof(Reload), _reloadTime);
            //Сделать рэйкаст и попадание

            RaycastHit hit;
            var rayCast = Physics.Raycast(_sightPosition.position, _sightPosition.forward, out hit);
            if (rayCast)
            {
                var rotation = new Quaternion(_sightPosition.rotation.x + 180, _sightPosition.rotation.y, _sightPosition.rotation.z, _sightPosition.rotation.w);


                GameObject decal = null;
                var targetGameObject = hit.collider.gameObject;
                if (targetGameObject.name.Equals("Terrain"))
                {
                    decal = Instantiate(_woodDecal, hit.point, rotation);
                }
                else if (targetGameObject.CompareTag("Metal") || targetGameObject.transform.parent.gameObject.CompareTag("Metal"))
                {
                    decal = Instantiate(_metallDecal, hit.point, rotation);
                }
                else if (targetGameObject.tag.Equals("Enemy"))
                {
                    decal = Instantiate(_bloodDecal, hit.point, rotation);
                    var health = targetGameObject.GetComponent<HealthController>();
                    health.Hurt(1);
                }

                if (decal != null)
                    decal.transform.parent = hit.collider.transform;
            }


            _animator.SetTrigger("shot");
            _muzzleFlashEffect.Play();
        }
    }

    private void Reload()
    {
        _isReload = false;
    }

    public void PlayShotSound()
    {
        _audioSource.Play();
    }

    private void ShootCompleted()
    {
        _animator.ResetTrigger("shot");
    }

    #endregion

}
