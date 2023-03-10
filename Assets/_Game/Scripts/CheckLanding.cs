using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    [SerializeField] private Transform startPos;

    // перенос телепорта
    public void OnWin()
    {
        startPos.position = transform.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
    }

    // перенос к телепорту
    public void OnLose()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = startPos.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
    }
}
