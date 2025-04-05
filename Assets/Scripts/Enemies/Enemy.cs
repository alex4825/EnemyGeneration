using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SphereCollider _detectionCollider;
    [SerializeField] private float _detectionRadius = 5;

    private Behaviors _behavior;

    private void Awake()
    {
        _behavior = Behaviors.Stay;
        _detectionCollider.radius = _detectionRadius;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _behavior = Behaviors.Reaction;
        Debug.Log($"Игрок попал в зону обнаружения врага {name}");
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _behavior = Behaviors.Stay;
        Debug.Log($"Игрок покинул зону обнаружения врага {name}");
    }
}
