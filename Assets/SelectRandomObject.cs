using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectRandomObject : MonoBehaviour
{
   [SerializeField] private int _countToLive = 1;

   public List<Toaster> _objectsPool;

   public void Clear()
   {
      _objectsPool = GetComponentsInChildren<Toaster>().ToList();
      _objectsPool.RemoveAll(item => item == null);
      
      print(_objectsPool.Count);
      /*while(_objectsPool.Count > _countToLive)
      {
         var index = Random.Range(0, _objectsPool.Count);
         //Destroy(_objectsPool[index].gameObject);
         //_objectsPool.RemoveAt(index);
      }*/
   }
   
}
