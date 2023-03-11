using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControlling : MonoBehaviour
{
    private Rigidbody physics;

    private void Start()
    {
        physics = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && physics.velocity.y <= 0)
        {
            physics.AddForce(new Vector3(0,0.02f,0f), ForceMode.Impulse);
        }
    }

    public void OnRightClick()
    {
        if (gameObject.GetComponent<ForceAdding>().enabled == false)
            physics.AddForce(GetVector(-1), ForceMode.Force);
    }

    public void OnLeftClick()
    {
        if (gameObject.GetComponent<ForceAdding>().enabled == false)
        {
            physics.AddForce(GetVector(1), ForceMode.Force);
        }
    }

    private Vector3 GetVector(float force)
    {
        var localPOS = gameObject.transform.localPosition;
        return new Vector3(20 * localPOS.x * force,0,0);
    }
}
