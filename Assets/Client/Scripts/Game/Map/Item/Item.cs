using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;

    public ItemType ItemType => _itemType;

    private Rigidbody _rb;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
    }

    public void OnSetup(float speed)
    {
        _rb.isKinematic = true;

        Move(-20f, speed);
    }

    private void Move(float targetX, float speed)
    {
        float distance = Mathf.Abs(_transform.position.x - targetX);
        float travelTime = distance / speed;

        // Motion with animation
        _transform.DOMoveX(targetX, travelTime)
            .SetEase(Ease.Linear)
            .OnComplete(DestroyItem);
    }

    public void TakeItem(Transform parent)
    {
        // The player took the item 
        DOTween.Kill(_transform);
        _rb.isKinematic = true;
        gameObject.tag = "Untagged";

        // Move the object into your hand
        _transform.SetParent(parent);
        _transform.localPosition = Vector3.zero;
    }

    public void PutItem()
    {
        // The player put the item 
        _transform.SetParent(null);
        _rb.isKinematic = false;

        if (_itemType == GameController.Instance.TargetItemType)
            GameEvents.InvokePutItemEvent(_itemType);
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}
