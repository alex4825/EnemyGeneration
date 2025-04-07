using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour, IDestroyable
{
    [SerializeField] private Mover _enemyMover;
    [SerializeField] private SphereCollider _detectionCollider;
    [SerializeField] private float _detectionRadius = 5;

    private States _state;
    private IBehavior _idleBehavior;
    private IBehavior _reactionBehavior;

    public Mover Mover => _enemyMover;
    public float DetectionRadius => _detectionRadius;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        _state = States.Idle;
        _detectionCollider.radius = _detectionRadius;
    }

    private void Update()
    {
        switch (_state)
        {
            case States.Idle:
                _idleBehavior.UpdateMovement();
                break;

            case States.Reaction:
                _reactionBehavior.UpdateMovement();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _state = States.Reaction;
        Debug.Log($"Игрок попал в зону обнаружения врага {name}");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _state = States.Idle;
        Debug.Log($"Игрок покинул зону обнаружения врага {name}");
    }

    public void SetIdle(IBehavior behavior) => _idleBehavior = behavior;

    public void SetReaction(IBehavior behavior) => _reactionBehavior = behavior;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
