﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    public GameObject PrevCollider = null;
    
    public int ScoreCount { get; private set; }

    // перенос телепорта
    public void OnWin(GameObject collider)
    {
        Debug.Log("win");
        var anch = collider.transform.Find("Anchor");
        Debug.Log(anch);
        if (anch != null)
        {
            Debug.Log("tp to anchor");
            transform.position = anch.position;
        }
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //startPos.position = transform.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        Debug.Log(gameObject.GetComponent<FlyControlling>().ToString());
        gameObject.GetComponent<FlyControlling>().enabled = false;
        //if (!collider.Equals(PrevCollider))
        //PlanesGenerator.GenerateNextPanel();
        //PrevCollider = collider;

        MakeScorePlus();
    }

    public void MakeScorePlus()
    {
        ScoreCount++;
        Debug.Log(ScoreCount);
    }

    // перенос к телепорту
    public void OnLose(GameObject collider)
    {
        Debug.Log("lose");
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = startPos.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        gameObject.GetComponent<FlyControlling>().enabled = false;
    }
}
