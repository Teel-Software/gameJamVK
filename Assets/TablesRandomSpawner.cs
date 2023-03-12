using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablesRandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _tableVariantPrefabs;

    private TableVariant[] _tableVariants;
    private Vector3  _currentSpawnPoint;
    private Vector3 _nextSpawnPoint;

    private void Start()
    {
        for (int i = 0; i < _tableVariantPrefabs.Length; i++)
        {
            //var table = new TableVariant(_tableVariantPrefabs[i], )
            //_tableVariantPrefabs[i].GetComponent<BoxCollider>().bounds.max.x
        }
    }
}

public class TableVariant
{
    public GameObject _tableObject { get;}
    public Vector3  _currentSpawnPoint { get;}
    public Vector3 _nextSpawnPoint { get;}

    public TableVariant(GameObject tableObject, Vector3 currentSpawnPoint, Vector3 nextSpawnPoint)
    {
        _tableObject = tableObject;
        _currentSpawnPoint = currentSpawnPoint;
        _nextSpawnPoint = nextSpawnPoint;
    }
}
