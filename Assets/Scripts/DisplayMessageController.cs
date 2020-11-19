using UnityEngine;

public class DisplayMessageController : MonoBehaviour
{
    [SerializeField] private UIDisplayController _uiDisplayController;
    [SerializeField] private string _message;

    [SerializeField] private float _duration = 10.0f;

    private bool isDisplayed;


    private void OnTriggerEnter(Collider other)
    {
        if (isDisplayed)
            return;

        if (other.gameObject.CompareTag("Player"))
        {
            isDisplayed = true;
            _uiDisplayController.DisplayCheckPointMessage(_message, _duration);
        }
    }
}
