using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private TableVariant[] _tables;
    [SerializeField] private TableVariant[] _tableVariants;
    
    public GameObject StartSpawnPoint;
    public GameObject EndSpawnPoint;

    public AnimationCurve ChanceFromDistance;

    public void ReplacePrefabInChunk()
    {
        Vector3 lastTableEndPosition;

        for (var i = 1; i < _tables.Length; i++)
        {
            var replaceableTable = _tables[i];
            var previousTable = _tables[i-1];
            
            var newTable = Instantiate(_tableVariants[Random.Range(0, _tableVariants.Length)], transform);

            lastTableEndPosition = previousTable.EndSpawnPoint.transform.position;
            var newTableStartPosition = newTable.StartSpawnPoint.transform.localPosition;

            newTable.transform.position = lastTableEndPosition - newTableStartPosition;
            Destroy(replaceableTable.gameObject);

            _tables[i] = newTable;
        }
        
        lastTableEndPosition = _tables[^1].EndSpawnPoint.transform.position;
        EndSpawnPoint.transform.position = lastTableEndPosition;
    }
}
