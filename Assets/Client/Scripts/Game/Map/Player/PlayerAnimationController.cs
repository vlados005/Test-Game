using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        GameEvents.OnLevelPassedEvent.AddListener(OnLevelPassedEvent);
    }

    private void OnLevelPassedEvent()
    {
        // Enable dance animation after victory 
        Invoke("PlayDanceAnim", 0.5f);
    }

    public void PlayIdleAnim()
    {
        _animator.SetTrigger("Idle");
    }

    public void PlayTakeItemAnim()
    {
        _animator.SetTrigger("TakeItem");
    }

    public void PlayPutItemAnim()
    {
        _animator.SetTrigger("PutItem");
    }

    public void PlayDanceAnim()
    {
        _animator.SetTrigger("Dance");
    }
}
