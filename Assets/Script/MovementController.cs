using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _rotateSpeed = 100;
    [SerializeField] private float _XminAngle = -60f;
    [SerializeField] private float _XmaxAngle = 60f;
    [SerializeField] private float _jumpForce = 50;
    [SerializeField] private float _gravityForce = -9.81f;
    // private float _horizontal;
    // private float _vertical;
    
    private CharacterController _characterController;
    private Vector3 _move;
    private float _verticalVelocity;
    private bool _isGrounded ;
    
    private float _mouseX;
    private float _mouseY;
    


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        UpdateMove();
        UpdateRotation();
        
    }


    private void UpdateMove()
    {
        // Horizontal movement
        Vector3 moveDirection = transform.TransformDirection(_move);
        moveDirection *= _moveSpeed;
        
        // Check grounded
        _isGrounded = _characterController.isGrounded;
        if (_isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f;
        }
        
        // Gravity
        _verticalVelocity += _gravityForce * Time.deltaTime;
        moveDirection.y = _verticalVelocity;
        
        // Apply movement and gravity
        _characterController.Move(moveDirection * Time.deltaTime);

    }
    
    private void UpdateRotation()
    {
        
        //Rotation
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");
        
        //Calculate body rotation
        Vector3 bodyRotation = new Vector3 (_mouseX,0, 0)* (_rotateSpeed* Time.deltaTime);
        
        //Apply rotation
        transform.Rotate(new Vector3(0, _mouseX, 0) * (_rotateSpeed * Time.deltaTime));

        Vector3 cameraRotation = new Vector3(-_mouseY, 0, 0);
        cameraRotation = _cameraTransform.rotation.eulerAngles + cameraRotation;
        cameraRotation.x = ClampAngle(cameraRotation.x, _XminAngle, _XmaxAngle);
        _cameraTransform.eulerAngles = cameraRotation;
    }

    private float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

    private void OnMove(InputValue input)
    {
        Vector2 movement = input.Get<Vector2>();
        _move.x = movement.x;
        _move.z = movement.y;
    }

    private void OnLook(InputValue input)
    {
        Vector2 look = input.Get<Vector2>();
        _mouseX = look.x;
        _mouseY = look.y;
    }

    private void OnJump(InputValue input)
    {
        if (_isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(_jumpForce * -2f * _gravityForce);
            Debug.Log(_verticalVelocity);
        }
    }

}