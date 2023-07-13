using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _targetItemAmountTxt;

    private GameController _gameController;
    private int _collectedItems;

    private void Start()
    {
        _gameController = GameController.Instance;
        GameEvents.OnPutItemEvent.AddListener(OnPutItemEvent);

        DisplayTask();
    }

    private void OnPutItemEvent(ItemType itemType)
    {
        if (itemType != GameController.Instance.TargetItemType)
            return;

        _collectedItems++;

        DisplayTask();
    }

    private void DisplayTask()
    {
        // Displaying the task on the screen
        int amaunt = _gameController.TargetItemAmount - _collectedItems;

        if (amaunt > 1)
            _targetItemAmountTxt.text = "Collect " + amaunt + " " + _gameController.TargetItemType + "s";
        else
            _targetItemAmountTxt.text = "Collect " + amaunt + " " + _gameController.TargetItemType;
    }
}
