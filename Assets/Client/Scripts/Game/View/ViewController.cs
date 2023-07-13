using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private LevelPassedView _levelPassedView;

    private void Start()
    {
        GameEvents.OnLevelPassedEvent.AddListener(OnLevelPassedEvent);
    }

    private void OnLevelPassedEvent()
    {
        Invoke("DisplayLevelPassedView", 2f);
    }

    private void DisplayLevelPassedView()
    {
        _gameView.gameObject.SetActive(false);
        _levelPassedView.gameObject.SetActive(true);
    }
}
