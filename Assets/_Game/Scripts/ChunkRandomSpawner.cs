using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ChunkRandomSpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnParent;

    [SerializeField] private List<Chunk> _chunkPrefabs = new();

    [SerializeField] private Chunk[] _defaultSpawnedChunks;

    [SerializeField] private float _offsetDistanceToLastChunkX = 15f;
    [SerializeField] private float _offsetDistanceToFirstChunkX = 5f;
    [SerializeField] private int _minSpawnedChunks = 5;
    [SerializeField] private int _maxSpawnedChunks = 10;

    [Space, SerializeField] private Chunk _emptySpaceVariant;
    [SerializeField] private float _emptySpaceValue = 3f;

    private List<Chunk> _spawnedChunks = new();

    private void Start()
    {
        //InitEmptySpaceVariant();

        InitStartTables();
        Spawn();
    }

    private void InitEmptySpaceVariant()
    {
        _emptySpaceVariant.StartSpawnPoint.transform.localPosition = new Vector3(_emptySpaceValue / 2, 0, 0);
        _emptySpaceVariant.EndSpawnPoint.transform.localPosition = new Vector3(-_emptySpaceValue / 2, 0, 0);

        _chunkPrefabs.Add(_emptySpaceVariant);
    }

    private void Update()
    {
        var lastTableEndPosition = _spawnedChunks.Last().EndSpawnPoint.transform.position;
        var firstTableStartPosition = _spawnedChunks.First().StartSpawnPoint.transform.position;

        if (_player.position.x < lastTableEndPosition.x + _offsetDistanceToLastChunkX)
        {
            Spawn();
        }

        if (_spawnedChunks.Count > _maxSpawnedChunks ||
            (_spawnedChunks.Count > _minSpawnedChunks &&
             _player.position.x > firstTableStartPosition.x + _offsetDistanceToFirstChunkX)) // нихера не работает эта строка. лень разбираться
            DestroyTable();
    }

    private void DestroyTable()
    {
        Destroy(_spawnedChunks[0].gameObject);
        _spawnedChunks.RemoveAt(0);
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        var newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Count)] /*GetRandomTableVariant()*/,
            _spawnParent);

        var lastTableEndPosition = _spawnedChunks.Last().EndSpawnPoint.transform.position;
        var newTableStartPosition = newChunk.StartSpawnPoint.transform.localPosition;

        newChunk.transform.position = lastTableEndPosition - newTableStartPosition;
        _spawnedChunks.Add(newChunk);
    }

    private Chunk GetRandomTableVariant()
    {
        var chances = new List<float>();

        foreach (var tableVariant in _chunkPrefabs)
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
                return _chunkPrefabs[i];
            }
        }

        return _chunkPrefabs[_chunkPrefabs.Count - 1];
    }

    private void InitStartTables()
    {
        foreach (var spawnedTable in _defaultSpawnedChunks)
        {
            _spawnedChunks.Add(spawnedTable);
        }
    }
}