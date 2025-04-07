using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 5;

    private const string NameAxisX = "Horizontal";
    private const string NameAxisZ = "Vertical";

    public Vector3 MoveDirection { get; private set; }

    public Speed Speed { get; private set; }

    private void Awake()
    {
        Speed = new(_initialSpeed);
    }

    private void Update()
    {
        SetMoveDirection();

        ProcessMovement();
    }

    private void ProcessMovement()
    {
        transform.Translate(MoveDirection * Speed.Value * Time.deltaTime, Space.World);
    }

    private void SetMoveDirection()
    {
        float verticalInput = Input.GetAxisRaw(NameAxisZ);
        float horizontalInput = Input.GetAxisRaw(NameAxisX);

        Vector3 moveDirectionNormalized = new Vector3(horizontalInput, 0, verticalInput).normalized;

        Vector3 cameraRightAxis = Camera.main.transform.right;
        Vector3 cameraForwardFlat = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;

        Vector3 horizontalDirection = cameraRightAxis * horizontalInput;
        Vector3 verticalDirection = cameraForwardFlat * verticalInput;
        MoveDirection = (horizontalDirection + verticalDirection).normalized;

    }
}
