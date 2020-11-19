using UnityEngine;


public class ActivationItemController : MonoBehaviour
{
    [SerializeField] private Transform _lookPosition;

    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _activationRange = 3.0f;


    public void Activate()
    {
        RaycastHit hit;
        Debug.DrawRay(_lookPosition.position, _lookPosition.forward * _activationRange, Color.red, 10.0f);
        var rayCast = Physics.Raycast(_lookPosition.position, _lookPosition.forward * _activationRange, out hit, _activationRange, _mask);
        if (!rayCast)
            return;
        
        var activationObjects = hit.collider.gameObject.GetComponents<IActivationObject>();
        print(hit.collider.gameObject.name);
        foreach (var activationObject in activationObjects)
            activationObject.Activate();
    }
}
