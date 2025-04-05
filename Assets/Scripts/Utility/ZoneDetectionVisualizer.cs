using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetectionVisualizer : MonoBehaviour
{
    [SerializeField] private SphereCollider _sphereCollider;

    private const float _unitsPerOneScale = 5f;

    private void Start()
    {
        transform.localScale *= _sphereCollider.radius / _unitsPerOneScale;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
