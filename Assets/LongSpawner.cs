using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LongSpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _offsetX = 15f;
    
    [SerializeField] private Transform _spawnParent;
    
    [SerializeField] private List<TableVariant> _objectPrefabs = new();
    
    [SerializeField] private TableVariant[] _defaultSpawnedObjects;

    private List<TableVariant> _spawnedObjects = new();

    private void Start()
    {
        InitStartTables();
        Spawn();
    }

    private void Update()
    {
        var lastTableEndPosition = _spawnedObjects.Last().EndSpawnPoint.transform.position;
        if (_player.position.x < lastTableEndPosition.x + _offsetX)
        {
            Spawn();
            DestroyTable();
        }
    }

    private void DestroyTable()
    {
        Destroy(_spawnedObjects[0].gameObject);
        _spawnedObjects.RemoveAt(0);
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        var newTable = Instantiate(GetRandomTableVariant(), _spawnParent);
        
        var lastTableEndPosition = _spawnedObjects.Last().EndSpawnPoint.transform.position;
        var newTableStartPosition = newTable.StartSpawnPoint.transform.localPosition;

        newTable.transform.position = lastTableEndPosition - 3 * newTableStartPosition;
        _spawnedObjects.Add(newTable);
    }

    private TableVariant GetRandomTableVariant()
    {
        var chances = new List<float>();

        foreach (var o in _objectPrefabs)
        {
            var chance = o.ChanceFromDistance.Evaluate(-_player.transform.position.x);
            chances.Add(chance);
        }

        var randomChance = Random.Range(0, chances.Sum());
        var currentChance = 0f;
        
        for (int i = 0; i < chances.Count; i++)
        {
            currentChance += chances[i];

            if (randomChance <= currentChance)
            {
                return _objectPrefabs[i];
            }
        }

        return _objectPrefabs[_objectPrefabs.Count-1];
    }

    private void InitStartTables()
    {
        foreach (var o in _defaultSpawnedObjects)
        {
            _spawnedObjects.Add(o);
        }
    }
}
