using UnityEngine;

public class RandomPatrol : IIdleBehavior
{
    private float _onePatrolMaxTime;
    private float _patrolTimer;
    private Vector3 _randomDirection;

    public RandomPatrol()
    {
        _onePatrolMaxTime = 1f;
        _patrolTimer = 0;
        UpdateRandomDirection();
    }

    public void ProcessMovement(Enemy enemy)
    {
        _patrolTimer += Time.deltaTime;

        if (_patrolTimer >= _onePatrolMaxTime)
        {
            _patrolTimer = 0;
            UpdateRandomDirection();
        }

        enemy.Mover.MoveTo(_randomDirection.normalized);
    }

    private void UpdateRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);

        _randomDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward;
    }
}
