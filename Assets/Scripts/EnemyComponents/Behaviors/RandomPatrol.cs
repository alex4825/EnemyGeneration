using UnityEngine;

public class RandomPatrol : IBehavior
{
    private float _onePatrolMaxTime;
    private float _patrolTimer;
    private Vector3 _randomDirection;
    private Mover _mover;

    public RandomPatrol(Mover mover)
    {
        _onePatrolMaxTime = 1f;
        _patrolTimer = 0;
        _mover = mover;
        UpdateRandomDirection();
    }

    public void UpdateMovement()
    {
        _patrolTimer += Time.deltaTime;

        if (_patrolTimer >= _onePatrolMaxTime)
        {
            _patrolTimer = 0;
            UpdateRandomDirection();
        }

        _mover.MoveTo(_randomDirection.normalized);
    }

    private void UpdateRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);

        _randomDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward;
    }
}
