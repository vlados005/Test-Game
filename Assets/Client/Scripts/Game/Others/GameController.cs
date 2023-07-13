using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { private set; get; }

    private ItemType _targetItemType;
    private int _targetItemAmount;
    private int _collectedItems;

    public ItemType TargetItemType => _targetItemType;
    public int TargetItemAmount => _targetItemAmount;
    public int CollectedItems => _collectedItems;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance.gameObject);
            Instance = this;
        }

        Set60Fps();
        SetLevelSettings();

        GameEvents.OnPutItemEvent.AddListener(OnPutItemEvent);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Set60Fps()
    {
        // Set frame rate to 60
        if (!Application.isEditor)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }

    private void SetLevelSettings()
    {
        // Generate a task for a level
        Array values = Enum.GetValues(typeof(ItemType));
        _targetItemType = (ItemType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        _targetItemAmount = UnityEngine.Random.Range(1, 6);
    }

    private void OnPutItemEvent(ItemType itemType)
    {
        if (itemType != _targetItemType)
            return;

        // Actions if the right item is taken 
        _collectedItems++;

        if (_collectedItems == _targetItemAmount)
            GameEvents.InvokeLevelPassedEvent();
    }

    public void LoadNextLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
