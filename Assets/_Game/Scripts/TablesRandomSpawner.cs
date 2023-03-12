using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TablesRandomSpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private TableVariant[] _tableVariantPrefabs;
    [SerializeField] private TableVariant[] _defaultSpawnedTables;
    [SerializeField] private float _offsetX = 15f;

    private List<TableVariant> _spawnedTables = new();

    private void Start()
    {
        InitStartTables();
        Spawn();
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
        var newTable = Instantiate(_tableVariantPrefabs[Random.Range(0, _tableVariantPrefabs.Length)], _spawnParent);
        
        var lastTableEndPosition = _spawnedTables.Last().EndSpawnPoint.transform.position;
        var newTableStartPosition = newTable.StartSpawnPoint.transform.localPosition;

        newTable.transform.position += lastTableEndPosition - newTableStartPosition;
        _spawnedTables.Add(newTable);
    }
    
    private void InitStartTables()
    {
        foreach (var spawnedTable in _defaultSpawnedTables)
        {
            _spawnedTables.Add(spawnedTable);
        }
    }
}