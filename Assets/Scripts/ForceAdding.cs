using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAdding : MonoBehaviour
{

    private float startTime;
    private const float MAX_TIME =5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(GetForceVector(),
                                                          ForceMode.Impulse);
            startTime = 0;
        }
    }

    private Vector3 GetForceVector()
    {
        var cameraVector = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Transform>().forward;
        var force = GetForcePercent();
        var newVector = new Vector3(50 * cameraVector.x * force,
                                    50 * force,
                                    50 * cameraVector.z * force);
        return newVector;
    }

    public float GetForcePercent()
    {
        if (startTime == 0) return 0;
        if (Time.time - startTime > MAX_TIME) return 1;
        return (Time.time - startTime) / MAX_TIME;
    }
}
