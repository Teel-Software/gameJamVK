using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAdding : MonoBehaviour
{
    [SerializeField] private TrajectoryRenderer renderer;
    private float startTime;
    private const float MAX_TIME =5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0) && startTime != 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(GetForceVector(),
                                                          ForceMode.Impulse);
            startTime = 0;
            renderer.ClearTraectory();
            gameObject.GetComponent<FlyControlling>().enabled = true;
            gameObject.GetComponent<ForceAdding>().enabled = false;
        }

        if(startTime != 0)
        {
            renderer.ShowTrajectory(gameObject.transform.position, GetForceVector());
        }
    }

    private Vector3 GetForceVector()
    {
        var cameraVector = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>().forward;
        var force = GetForcePercent();
        var newVector = new Vector3(50 * cameraVector.x * force,
                                    50 * force,
                                    50 * cameraVector.z * force);
        return newVector;
    }

    public float GetForcePercent()
    {
        if (startTime == 0) return 0;
        float percent = (Time.time - startTime) / MAX_TIME;
        if ((int)percent % 2 == 0) return percent - (int)percent;
        return 1 - (percent - (int)percent);
    }
}
