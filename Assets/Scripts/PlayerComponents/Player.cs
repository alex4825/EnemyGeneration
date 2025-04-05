using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private int _healthValue = 100;

    public Mover Mover => _mover;
    public Health Health { get; private set; }

    private void Awake()
    {
        Health = new(_healthValue);
    }    
}
