using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed
{
    public float Value { get; private set; }

    public Speed(float value)
    {
        Value = value;
    }

    public void Add(float value)
    {
        Value += value;
    }
}
