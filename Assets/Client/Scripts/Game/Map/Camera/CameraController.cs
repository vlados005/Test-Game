using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCamera;
    [SerializeField] private GameObject _levelPassedCamera;

    private void Start()
    {
        GameEvents.OnLevelPassedEvent.AddListener(OnLevelPassedEvent);
    }

    private void OnLevelPassedEvent()
    {
        // Turn on the victory cam 
        _defaultCamera.SetActive(false);
        _levelPassedCamera.SetActive(true);
    }
}
