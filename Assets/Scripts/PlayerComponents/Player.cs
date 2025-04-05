using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    public Mover Mover => _mover;
}
