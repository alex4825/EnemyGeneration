using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : IBehavior
{
    private Transform _dangerTransform;
    private Mover _mover;

    public RunAway(Mover mover, Transform dangerTransform)
    {
        _dangerTransform = dangerTransform;
        _mover = mover;
    }

    public void UpdateMovement()
    {
        Vector3 directionAwayFromDanger = (_mover.transform.position - _dangerTransform.position).normalized;
        _mover.MoveTo(directionAwayFromDanger);
    }
}
