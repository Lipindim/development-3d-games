using UnityEngine;


public class GameObjectActivator : MonoBehaviour, IActivationObject
{
    [SerializeField] private GameObject _activatedObject;

    public void Activate()
    {
        _activatedObject.SetActive(true);
    }

}
