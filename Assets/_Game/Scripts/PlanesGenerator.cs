using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanesGenerator
{
    private static List<GameObject> planes = new List<GameObject>();

    public static void GenerateNextPanel()
    {
        var prefab = Resources.Load<GameObject>("Win");
        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        var curPosition = player.GetComponent<Transform>().position;
        var obj = MonoBehaviour.Instantiate(prefab, new Vector3(curPosition.x + Random.Range(1,5),
                                                                curPosition.y + Random.Range(1, 5),
                                                                curPosition.z + Random.Range(40, 60)), new Quaternion());
        var enteredEvent = new UnityGameObjectEvent();
        enteredEvent.AddListener(player.GetComponent<CheckLanding>().OnWin);
        obj.GetComponent<EntryZoneComponent>().SetZoneEnteredEvent(enteredEvent);
        planes.Add(obj);

    }
}
