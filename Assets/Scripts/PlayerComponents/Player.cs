using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;

    public PlayerMover Mover => _mover;
}
