using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class DepthOfFieldController : MonoBehaviour
{
    private const float DEPTH_OFFSET = 1.5f;


    [SerializeField] private Transform _lookPosition;
    [SerializeField] private PostProcessVolume postProcessVolume;

    [SerializeField] private float _depthChangeSpeed = 5.0f;

    private DepthOfField depthOfField;


    private void Start()
    {
        depthOfField = postProcessVolume.profile.GetSetting<DepthOfField>();

    }


    private void Update()
    {
        RaycastHit hit;
        var rayCast = Physics.Raycast(_lookPosition.position, _lookPosition.forward, out hit);
        if (!rayCast)
            return;

        if (depthOfField.focusDistance.value - DEPTH_OFFSET < hit.distance)
        {
            //depthOfField.focusDistance.value += Time.deltaTime * _depthChangeSpeed;
            depthOfField.focusDistance.value += (hit.distance - depthOfField.focusDistance.value + DEPTH_OFFSET) / 10;
        }

        if (depthOfField.focusDistance.value - DEPTH_OFFSET > hit.distance)
        {
            //depthOfField.focusDistance.value -= Time.deltaTime * _depthChangeSpeed;
            depthOfField.focusDistance.value -= (depthOfField.focusDistance.value - DEPTH_OFFSET + hit.distance) / 10;
        }

        print($"{depthOfField.focusDistance.value:n2}:{hit.distance:n2}");
    }
}
