using System.Collections.Generic;
using UnityEngine;

public class QueueMovement: MonoBehaviour
{
    // By default this component disable itself if it has nowhere to go
    // Fill the queue with waypoints, then enable component to move through them in order

    [SerializeField]
    Queue<Vector3> pathPoints = new Queue<Vector3>();

    float _moveSpeed = 20f;
    float _reachedLocRadius = 5f;

    void Awake()
    {
        if (GetComponent<PeasantStats>())
            InitializeMoveStats();
    }

    void Update()
    {
        if (pathPoints.Count == 0)
        {
            this.enabled = false;
            return;
        }

        MoveThroughPoints();
    }

    #region Public Methods

    public void AddToQueue(Vector3 point)
    {
        pathPoints.Enqueue(point);
    }

    public void ClearQueue()
    {
        pathPoints.Clear();
    }

    #endregion

    #region Private Method

    void MoveThroughPoints()
    {
        Vector3 currentDestination = pathPoints.Peek();

        if (UpdateSetDestination(currentDestination))
        {
            pathPoints.Dequeue();
            currentDestination = pathPoints.Peek();
        }

        Vector3 dir = (currentDestination - transform.position).normalized;
        transform.Translate(dir * _moveSpeed * Time.deltaTime);
    }

    #endregion

    #region Constructor

    void InitializeMoveStats()
    {
        PeasantStats ps = GetComponent<PeasantStats>();

        _moveSpeed = ps.moveSpeed;
        _reachedLocRadius = ps.reachLocRadius;
    }

    #endregion

    #region Helper Methods

    bool UpdateSetDestination(Vector3 currentDestination)
    {
        if (pathPoints.Count == 0)
        {
            this.enabled = false;
            return false;
        }

        if (RemainingDistance(currentDestination) < _reachedLocRadius)
            return true;

        return false;
    }

    Vector3 CalcDirection(Vector3 target)
    {
        return (target - transform.position).normalized;
    }

    float RemainingDistance(Vector3 target)
    {
        float distance = (target - transform.position).magnitude;
        return distance;
    }

    #endregion
}
