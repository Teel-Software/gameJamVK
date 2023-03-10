using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanesGenerator
{
    private static Queue<GameObject> planes = new Queue<GameObject>();

    public static void GenerateNextPanel()
    {
        var prefab = Resources.Load<GameObject>("Win");
        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        var curPosition = player.GetComponent<Transform>().position;
        var obj = MonoBehaviour.Instantiate(prefab, new Vector3(curPosition.x + Random.Range(1,5),
                                                                curPosition.y + Random.Range(1, 5),
                                                                curPosition.z + Random.Range(40, 60)), new Quaternion());
        var enteredEvent = new UnityEngine.Events.UnityEvent();
        enteredEvent.AddListener(player.GetComponent<CheckLanding>().OnWin);
        obj.GetComponent<EntryZoneComponent>().SetZoneEnteredEvent(enteredEvent);
        planes.Enqueue(obj);

        while(planes.Count > 3)
        {
            MonoBehaviour.Destroy(planes.Dequeue());
        }
    }
}
