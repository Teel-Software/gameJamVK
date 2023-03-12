using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoseActionAutoSetter : MonoBehaviour
{
    void Start()
    {
        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        var enteredEvent = new UnityGameObjectEvent();
        enteredEvent.AddListener(player.GetComponent<CheckLanding>().OnLose);
        var zones = gameObject.GetComponents<EntryZoneComponent>();
        foreach(var zone in zones)
            zone.SetZoneEnteredEvent(enteredEvent);
    }
}
