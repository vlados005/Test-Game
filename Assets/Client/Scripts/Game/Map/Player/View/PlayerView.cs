using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayerInfoTxt _infoTxtPrefub;
    [SerializeField] private RectTransform _infoTxtSpawnPosition;

    private Transform _cameraTransform;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _cameraTransform = Camera.main.transform;

        GameEvents.OnPutItemEvent.AddListener(OnPutItemEvent);
    }

    private void LateUpdate()
    {
        // Turn the canvas toward the camera
        if (_cameraTransform != null)
            _transform.LookAt(_transform.position + _cameraTransform.rotation * Vector3.forward, _cameraTransform.rotation * Vector3.up);
    }

    private void SpawnInfoTxt()
    {
        // Spawns PlayerInfoTxt with the text +1
        PlayerInfoTxt text = Instantiate(_infoTxtPrefub, _infoTxtSpawnPosition.position, _infoTxtSpawnPosition.rotation, _transform);
        text.SetText("+1");
    }

    private void OnPutItemEvent(ItemType itemType)
    {
        if (itemType != GameController.Instance.TargetItemType)
            return;

        SpawnInfoTxt();
    }
}
