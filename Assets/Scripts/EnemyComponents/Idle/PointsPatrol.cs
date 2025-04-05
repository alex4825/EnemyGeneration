using System.Collections.Generic;
using UnityEngine;

public class PointsPatrol : IIdleBehavior
{
    private List<SpawnPoint> _points;
    private SpawnPoint _targetPoint;
    //private int _targetPointNumber = 0;
    private bool _isPointReached;
    private float _reachDistance = 0.2f;

    public PointsPatrol(List<SpawnPoint> points)
    {
        _points = points;
        UpdateTargetPoint();
    }

    public void ProcessMovement(Enemy enemy)
    {
        _isPointReached = (GetVectorToTargetPointFrom(enemy).magnitude < _reachDistance);

        if (_isPointReached)
        {
            UpdateTargetPoint();
        }

        Vector3 direction = GetVectorToTargetPointFrom(enemy).normalized;

        enemy.Mover.MoveTo(direction);
    }

    private Vector3 GetVectorToTargetPointFrom(Enemy enemy)
        => _targetPoint.transform.position - enemy.transform.position;

    private void UpdateTargetPoint()
    {
        _targetPoint = _points[Random.Range(0, _points.Count)];

        /*if (_targetPointNumber < _points.Count - 1)
            _targetPointNumber++;
        else
            _targetPointNumber = 0;

        _targetPoint = _points[_targetPointNumber];*/
    }
}
