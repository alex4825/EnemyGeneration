using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PositiveProperty : MonoBehaviour
{
    public float Value { get; private set; }

    public PositiveProperty(float value)
    {
        Value = value;
    }

    public void Add(float value)
    {
        Value += value;
    }
}
