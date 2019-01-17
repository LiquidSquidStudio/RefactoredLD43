using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Gather together all the child transforms in a list to use elsewhere

    List<Vector3> pathPoints;

    void Awake()
    {
        pathPoints = new List<Vector3>();
        PopulatePath();
    }

    void PopulatePath()
    {
        foreach (Transform child in transform)
            pathPoints.Add(child.position);
    }

    public List<Vector3> PathPoints()
    {
        return pathPoints;
    }
}
