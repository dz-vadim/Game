using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRendererComponennt;
    

    void Start()
    {
        lineRendererComponennt = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 startPoint,Vector3 endPoint)
    {
        Vector3[] points = new Vector3[2] { startPoint, endPoint};

        lineRendererComponennt.positionCount = points.Length;
        lineRendererComponennt.SetPositions(points);
    }
}
