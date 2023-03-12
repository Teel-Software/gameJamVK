using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWinActionAutoSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        var enteredEvent = new UnityGameObjectEvent();
        enteredEvent.AddListener(player.GetComponent<CheckLanding>().OnWin);
        gameObject.GetComponent<EntryZoneComponent>().SetZoneEnteredEvent(enteredEvent);
    }
}
