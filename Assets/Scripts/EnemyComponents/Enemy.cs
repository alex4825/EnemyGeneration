using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour, IDestroyable
{
    [SerializeField] private Mover _enemyMover;
    [SerializeField] private SphereCollider _detectionCollider;
    [SerializeField] private float _detectionRadius = 5;

    private IBehavior _idleBehavior;
    private IBehavior _reactionBehavior;
    private IBehavior _currentBehavior;

    public Mover Mover => _enemyMover;
    public float DetectionRadius => _detectionRadius;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        _detectionCollider.radius = _detectionRadius;
    }

    private void Update()
    {
        _currentBehavior.UpdateMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _currentBehavior = _reactionBehavior;
        Debug.Log($"Игрок попал в зону обнаружения врага {name}");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _currentBehavior = _idleBehavior;
        Debug.Log($"Игрок покинул зону обнаружения врага {name}");
    }

    public void SetIdle(IBehavior behavior)
    {
        _idleBehavior = behavior;
        _currentBehavior = _idleBehavior;
    }

    public void SetReaction(IBehavior behavior) => _reactionBehavior = behavior;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
