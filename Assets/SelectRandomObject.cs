using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectRandomObject : MonoBehaviour
{
   [SerializeField] private int _countToLive = 1;

   private List<Toaster> _objectsPool;

   public void Clear()
   {
      _objectsPool = GetComponentsInChildren<Toaster>().ToList();
      while(_objectsPool.Count > _countToLive)
      {
         var index = Random.Range(0, _objectsPool.Count);
         Destroy(_objectsPool[index].gameObject);
         _objectsPool.RemoveAt(index);
      }
   }
   
}
