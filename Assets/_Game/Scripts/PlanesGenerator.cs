using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanesGenerator
{
    private static List<GameObject> planes = new List<GameObject>();
    private static Vector3 curPosition = Vector3.zero;

    public static void GenerateNextPanel()
    {
        var prefab = Resources.Load<GameObject>("Win");
        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        if (curPosition == Vector3.zero) 
            curPosition = GameObject.FindGameObjectsWithTag("Start")[0]
                                    .GetComponent<Transform>()
                                    .position;
        curPosition.z += Random.Range(30, 50);
        var obj = MonoBehaviour.Instantiate(prefab, curPosition, new Quaternion());
        var enteredEvent = new UnityGameObjectEvent();
        enteredEvent.AddListener(player.GetComponent<CheckLanding>().OnWin);
        obj.GetComponent<EntryZoneComponent>().SetZoneEnteredEvent(enteredEvent);
        planes.Add(obj);

    }
}
