using UnityEngine.Events;

public class GameEvents
{
    public static readonly UnityEvent<ItemType> OnPutItemEvent = new UnityEvent<ItemType>();
    public static readonly UnityEvent OnLevelPassedEvent = new UnityEvent();

    public static void InvokePutItemEvent(ItemType itemType)
    {
        OnPutItemEvent.Invoke(itemType);
    }
    public static void InvokeLevelPassedEvent()
    {
        OnLevelPassedEvent.Invoke();
    }
}
