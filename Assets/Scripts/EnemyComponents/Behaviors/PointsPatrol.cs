using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointsPatrol : IBehavior
{
    private List<SpawnPoint> _points;
    private SpawnPoint _targetPoint;
    private Mover _mover;
    private bool _isPointReached;
    private float _reachDistance = 0.2f;

    public PointsPatrol(Mover mover, List<SpawnPoint> points)
    {
        _mover = mover;
        _points = points;
        UpdateTargetPoint();
    }

    public void UpdateMovement()
    {
        _isPointReached = (GetVectorToTargetPointFrom(_mover.transform).magnitude < _reachDistance);

        if (_isPointReached)
        {
            UpdateTargetPoint();
        }

        Vector3 direction = GetVectorToTargetPointFrom(_mover.transform).normalized;

        _mover.MoveTo(direction);
    }

    private Vector3 GetVectorToTargetPointFrom(Transform point)
        => _targetPoint.transform.position - point.position;

    private void UpdateTargetPoint()
    {
        _targetPoint = _points[Random.Range(0, _points.Count)];
    }
}
