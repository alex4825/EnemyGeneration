using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private PlayerMover _mover;

    private void Update()
    {
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (_mover.MoveDirection != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(_mover.MoveDirection);
            float rotationStep = _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationStep);
        }
    }
}
