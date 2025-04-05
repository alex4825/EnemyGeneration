using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _trackingTarget;
    [SerializeField] private Vector3 _initialOffset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float _movingSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] private float _minVerticalAngle = 35f;
    [SerializeField] private float _maxVerticalAngle = 70f;

    private float _currentHorizontalAngle;
    private float _currentVerticalAngle;
    private float _distance;

    private void Start()
    {
        _distance = _initialOffset.magnitude;
        _currentHorizontalAngle = Mathf.Atan2(_initialOffset.x, _initialOffset.z) * Mathf.Rad2Deg;
        float horizontalDistance = new Vector2(_initialOffset.x, _initialOffset.z).magnitude;
        _currentVerticalAngle = Mathf.Atan2(_initialOffset.y, horizontalDistance) * Mathf.Rad2Deg;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            _currentHorizontalAngle += Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            _currentVerticalAngle -= Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
            _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle, _minVerticalAngle, _maxVerticalAngle);
        }

        float radHorizontal = _currentHorizontalAngle * Mathf.Deg2Rad;
        float radVertical = _currentVerticalAngle * Mathf.Deg2Rad;

        Vector3 offset;
        offset.x = _distance * Mathf.Sin(radHorizontal) * Mathf.Cos(radVertical);
        offset.z = _distance * Mathf.Cos(radHorizontal) * Mathf.Cos(radVertical);
        offset.y = _distance * Mathf.Sin(radVertical);

        Vector3 targetPosition = _trackingTarget.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _movingSpeed * Time.deltaTime);
        transform.LookAt(_trackingTarget.position);
    }
}