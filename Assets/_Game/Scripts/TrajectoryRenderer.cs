using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRendererComponent;
    [SerializeField] private float GROUND_LEVEL = 0;

    private void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        lineRendererComponent.enabled = true;
        Vector3[] points = new Vector3[100];
        lineRendererComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

            if (points[i].y < GROUND_LEVEL)
            {
                lineRendererComponent.positionCount = i + 1;
                break;
            }
        }

        lineRendererComponent.SetPositions(points);
    }

    public void ClearTraectory()
    {
        lineRendererComponent.enabled = false;
    }
}
