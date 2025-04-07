using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyable
{
    float DetectionRadius { get; }

    Vector3 Position { get; }

    void DestroySelf();
}
