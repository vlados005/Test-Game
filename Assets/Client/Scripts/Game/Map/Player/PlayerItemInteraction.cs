using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerItemInteraction : MonoBehaviour
{
    [SerializeField] private Transform _handParent;
    [SerializeField] private Transform _animationHandTarget;
    [SerializeField] private PlayerAnimationController _animationController;

    private Item _item;

    private bool _isItemTaken;
    private bool _canTakeItem = true;

    private void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            TakeItem();

        UpdateAnimationHandPosition();
    }

    private void TakeItem()
    {
        if (!_canTakeItem || _isItemTaken || _item == null)
            return;

        // Enable item picking animation
        _canTakeItem = false;
        _animationController.PlayTakeItemAnim();
    }

    private void UpdateAnimationHandPosition()
    {
        // Set the position of the target as an item
        if (_item != null && !_isItemTaken)
            _animationHandTarget.position = _item.transform.position;
    }

    public void AnimationTakeItem()
    {
        // Calls out in an animated clip 
        if (_item == null)
        {
            FinishItemInteraction();
            return;
        }

        // If the player was able to reach and grab the item
        _isItemTaken = true;
        _item.TakeItem(_handParent);
        _animationController.PlayPutItemAnim();
    }

    public void AnimationPutItem()
    {
        // Calls out in an animated clip
        // Put the item down
        _item.PutItem();
        _item = null;

        _isItemTaken = false;
        FinishItemInteraction();
    }

    private void FinishItemInteraction()
    {
        // Enable idle animation
        _canTakeItem = true;
        _animationController.PlayIdleAnim();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Item in range
        if (other.CompareTag("Item"))
        {
            if (!_isItemTaken && _item == null && other.TryGetComponent<Item>(out Item item))
                _item = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Element out of range
        if (other.CompareTag("Item"))
        {
            if (other.TryGetComponent<Item>(out Item item))
            {
                if (!_isItemTaken && _item == item)
                    _item = null;
            }
        }
    }
}
