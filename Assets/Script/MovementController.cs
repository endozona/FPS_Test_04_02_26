using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _rotateSpeed = 100;
    [SerializeField] private float _XminAngle = -60f;
    [SerializeField] private float _XmaxAngle = 60f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //create vector3 
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        //turn local direction into world space
        Vector3 transformDirection = transform.TransformDirection(movement);

        // Apply movement
        _characterController.Move(transformDirection * (_moveSpeed * Time.deltaTime));

        //Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        //Calculate body rotation
        Vector3 bodyRotation = new Vector3 (0, mouseX, 0)* (_rotateSpeed* Time.deltaTime);
        
        //Apply rotation
        transform.Rotate(new Vector3(0, mouseX, 0) * (_rotateSpeed * Time.deltaTime));

        Vector3 cameraRotation = new Vector3(-mouseY, 0, 0);
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

}