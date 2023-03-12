using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TablesRandomSpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnParent;
    
    [SerializeField] private List<TableVariant> _tableVariantPrefabs = new();
    
    [SerializeField] private TableVariant[] _defaultSpawnedTables;
    
    [SerializeField] private float _offsetX = 15f;
    
    [Space, SerializeField] private TableVariant _emptySpaceVariant;
    [SerializeField] private float _emptySpaceValue = 3f;

    private List<TableVariant> _spawnedTables = new();

    private void Start()
    {
        InitEmptySpaceVariant();

        InitStartTables();
        Spawn();
    }

    private void InitEmptySpaceVariant()
    {
        _emptySpaceVariant.StartSpawnPoint.transform.localPosition = new Vector3(_emptySpaceValue / 2, 0, 0);
        _emptySpaceVariant.EndSpawnPoint.transform.localPosition = new Vector3(-_emptySpaceValue / 2, 0, 0);

        _tableVariantPrefabs.Add(_emptySpaceVariant);
    }

    private void Update()
    {
        var lastTableEndPosition = _spawnedTables.Last().EndSpawnPoint.transform.position;
        if (_player.position.x < lastTableEndPosition.x + _offsetX)
        {
            Spawn();
            DestroyTable();
        }
    }

    private void DestroyTable()
    {
        Destroy(_spawnedTables[0].gameObject);
        _spawnedTables.RemoveAt(0);
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        var newTable = Instantiate(GetRandomTableVariant(), _spawnParent);
        
        var lastTableEndPosition = _spawnedTables.Last().EndSpawnPoint.transform.position;
        var newTableStartPosition = newTable.StartSpawnPoint.transform.localPosition;

        newTable.transform.position += lastTableEndPosition - newTableStartPosition;
        _spawnedTables.Add(newTable);
    }

    private TableVariant GetRandomTableVariant()
    {
        var chances = new List<float>();

        foreach (var tableVariant in _tableVariantPrefabs)
        {
            var chance = tableVariant.ChanceFromDistance.Evaluate(-_player.transform.position.x);
            chances.Add(chance);
        }

        var randomChance = Random.Range(0, chances.Sum());
        var currentChance = 0f;
        
        for (int i = 0; i < chances.Count; i++)
        {
            currentChance += chances[i];

            if (randomChance <= currentChance)
            {
                return _tableVariantPrefabs[i];
            }
        }

        return _tableVariantPrefabs[_tableVariantPrefabs.Count-1];
    }

    private void InitStartTables()
    {
        foreach (var spawnedTable in _defaultSpawnedTables)
        {
            _spawnedTables.Add(spawnedTable);
        }
    }
}