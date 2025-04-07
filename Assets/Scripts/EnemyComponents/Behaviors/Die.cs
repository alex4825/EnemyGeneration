using System.Collections;
using UnityEngine;

public class Die : IBehavior
{
    private IDestroyable _destructibleObject;
    private Transform _dangerTransform;

    public Die(IDestroyable destructibleObject, Transform dangerTransform)
    {
        _destructibleObject = destructibleObject;
        _dangerTransform = dangerTransform;
    }

    public void UpdateMovement()
    {
        float distanceToOther = (_dangerTransform.position - _destructibleObject.Position).magnitude;

        if (distanceToOther < _destructibleObject.DetectionRadius)
        {
            _destructibleObject.DestroySelf();
        }
    }
}
