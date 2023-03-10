using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    private bool notNewPanel = false;

    // перенос телепорта
    public void OnWin()
    {
        startPos.position = transform.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        if (!notNewPanel)
        {
            PlanesGenerator.GenerateNextPanel();
        }
            notNewPanel = false;
    }

    // перенос к телепорту
    public void OnLose()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = startPos.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        notNewPanel = true;
    }
}
