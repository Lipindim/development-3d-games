using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _initialForce = 3.0f;

    private Rigidbody _rigidbody;


    public void SpawnObject()
    {
        var spawnObject = Instantiate(_spawnObject, _spawnPoint);
        spawnObject.GetComponent<Rigidbody>().AddForce((transform.up + transform.right) * _initialForce, ForceMode.Impulse);
    }
}
