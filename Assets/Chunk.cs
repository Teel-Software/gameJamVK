using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private TableVariant[] _tables;
    [SerializeField] private TableVariant[] _tableVariants;
    [SerializeField] private SelectRandomObject _selector;
    
    public GameObject StartSpawnPoint;
    public GameObject EndSpawnPoint;

    public AnimationCurve ChanceFromDistance;
    
    private void Start()
    {
        foreach (var table in _tables)
        {
            var pos = table.transform.position;
            var newTable = Instantiate(_tableVariants[Random.Range(0, _tableVariants.Length)], transform);
            newTable.transform.position = pos;
            Destroy(table.gameObject);
        }
        _selector.Clear();
    }
}
