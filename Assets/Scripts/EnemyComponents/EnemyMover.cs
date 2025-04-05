using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    public void MoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
