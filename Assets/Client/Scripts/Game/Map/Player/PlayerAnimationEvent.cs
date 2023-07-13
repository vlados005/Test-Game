using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    [SerializeField] private PlayerItemInteraction _playerItemInteraction;

    private void OnAnimationTakeItem()
    {
        _playerItemInteraction.AnimationTakeItem();
    }

    private void OnAnimationPutItem()
    {
        _playerItemInteraction.AnimationPutItem();
    }
}
