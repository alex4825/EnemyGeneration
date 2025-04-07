using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUp : IBehavior
{
    private Transform _dangerTransform;
    private Mover _targetMover;

    public CatchUp(Mover mover, Transform targetTransform)
    {
        _dangerTransform = targetTransform;
        _targetMover = mover;
    }

    public void UpdateMovement()
    {
        Vector3 directionToTarget = (_dangerTransform.position - _targetMover.transform.position).normalized;

        _targetMover.MoveTo(directionToTarget);
    }
}
