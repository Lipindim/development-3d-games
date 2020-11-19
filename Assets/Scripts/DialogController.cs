using UnityEngine;


public class DialogController : MonoBehaviour, IActivationObject
{

    [SerializeField] private UIDisplayController _uiDisplayController;
    [SerializeField] private string _dialogMessage;

    private bool _isDialogActivated;


    public void Activate()
    {
        if (_isDialogActivated)
            return;

        _uiDisplayController.DisplayCheckPointMessage(_dialogMessage, 20.0f);
        _isDialogActivated = true;
    }
}
