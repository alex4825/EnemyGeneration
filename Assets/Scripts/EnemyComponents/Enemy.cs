using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private SphereCollider _detectionCollider;
    [SerializeField] private float _detectionRadius = 5;

    private States _state;
    private IIdleBehavior _idleBehavior;
    private IReactionBehavior _reactionBehavior;

    private Player _player;

    public EnemyMover Mover => _enemyMover;
    public float DetectionRadius => _detectionRadius;

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
                _idleBehavior.ProcessMovement(this);
                break;

            case States.Reaction:
                _reactionBehavior.ProcessReaction(this, _player);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _player = other.GetComponent<Player>();

        if (_player == null)
            return;

        _state = States.Reaction;
        Debug.Log($"Игрок попал в зону обнаружения врага {name}");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        _player = null;
        _state = States.Idle;
        Debug.Log($"Игрок покинул зону обнаружения врага {name}");
    }

    public void Set(IIdleBehavior idleBehavior) => _idleBehavior = idleBehavior;

    public void Set(IReactionBehavior reactionBehavior) => _reactionBehavior = reactionBehavior;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    
}
