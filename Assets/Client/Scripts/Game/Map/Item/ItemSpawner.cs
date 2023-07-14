using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _conveyor;
    [SerializeField] private List<Item> _itemPrefabs;

    private void Start()
    {
        CustomizeListItems();
        StartCoroutine(WaitAndSpawnItem());

        GameEvents.OnLevelPassedEvent.AddListener(OnLevelPassedEvent);
    }

    private void OnLevelPassedEvent()
    {
        _conveyor.SetActive(false);
        gameObject.SetActive(false);
    }

    private void CustomizeListItems()
    {
        // Increase the likelihood of obtaining the desired item
        for (int i = 0; i < _itemPrefabs.Count; i++)
        {
            if (_itemPrefabs[i].ItemType == GameController.Instance.TargetItemType)
            {
                _itemPrefabs.Add(_itemPrefabs[i]);
                break;
            }
        }
    }

    private void SpawnRandomItem()
    {
        // Spawn a random item 
        int r = Random.Range(0, _itemPrefabs.Count);
        Item item = Instantiate(_itemPrefabs[r], _spawnPosition.position, Quaternion.identity, _spawnPosition);
        item.OnSetup(_speed);
    }

    IEnumerator WaitAndSpawnItem()
    {
        // Spawn an item every 2-3 seconds
        while (true)
        {
            SpawnRandomItem();
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }
}
