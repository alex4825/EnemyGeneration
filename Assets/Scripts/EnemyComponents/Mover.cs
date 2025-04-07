using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    public void MoveTo(Vector3 direction)
    {
        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;

        transform.Translate(horizontalDirection * _speed * Time.deltaTime);
    }
}
