using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControlling : MonoBehaviour
{ 
    public void OnRightClick()
    {
        if (gameObject.GetComponent<ForceAdding>().enabled == false)
            gameObject.GetComponent<Rigidbody>().AddForce(GetVector(-1), ForceMode.Force);
    }

    public void OnLeftClick()
    {
        if (gameObject.GetComponent<ForceAdding>().enabled == false)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(GetVector(1), ForceMode.Force);
        }
    }

    private Vector3 GetVector(float force)
    {
        var localPOS = gameObject.transform.localPosition;
        return new Vector3(20 * localPOS.x * force,0,0);
    }
}
