using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    public GameObject PrevCollider;

    // перенос телепорта
    public void OnWin(GameObject collider)
    {
        startPos.position = transform.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        gameObject.GetComponent<FlyControlling>().enabled = false;
        if (!PrevCollider.Equals(collider))
        PlanesGenerator.GenerateNextPanel();
        PrevCollider = collider;
    }

    // перенос к телепорту
    public void OnLose(GameObject collider)
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = startPos.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        gameObject.GetComponent<FlyControlling>().enabled = false;
    }
}
