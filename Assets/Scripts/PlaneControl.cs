using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneControl : MonoBehaviour
{
    [SerializeField] private float _planeDefaultSpeed;
    [SerializeField] private float _planeSpeedMultiplier;
    [SerializeField] private float _planeBreakMultiplier;
    [SerializeField] private float _sideRotationSpeed;
    [SerializeField] private float _verticalRotationSpeed;
    [SerializeField] private Transform _camera;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    { 
        Vector3 horizontal = ControlHorizontalRotation();
        Vector3 vertical = ControlVerticalRotation();
        MoveForward(vertical, horizontal);
    }

    private void MoveForward(Vector3 up, Vector3 right)
    {
        float minSpeed = 1f;
        float maxSpeed = 100f;
        float speedControl = Mathf.Clamp(_planeDefaultSpeed * ControlAcceleration(), minSpeed, maxSpeed);

        _rigidbody.velocity = transform.TransformDirection(Vector3.forward * speedControl);
    }

    private float ControlAcceleration()
    {
        float acceleration = 1;
        if (Input.GetKey(KeyCode.Space))
        {
            acceleration /= _planeBreakMultiplier;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration *= _planeSpeedMultiplier;
        }
        else
        {
            acceleration = 1;
        }
        
        return acceleration;
    }

    private Vector3 ControlHorizontalRotation()
    {
        Vector3 leftRotation = Vector3.forward.normalized * (_sideRotationSpeed * Time.fixedDeltaTime);
        Vector3 rightRotation = Vector3.forward.normalized * - (_sideRotationSpeed * Time.fixedDeltaTime);
        
        Vector3 resultVector = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
           resultVector = leftRotation;
            _rigidbody.AddRelativeTorque(leftRotation, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            resultVector = rightRotation;
            _rigidbody.AddRelativeTorque(rightRotation, ForceMode.Impulse);
        }

        return resultVector;
    }

    private Vector3 ControlVerticalRotation()
    {
        Vector3 downRotation = Vector3.right.normalized * (_verticalRotationSpeed * Time.fixedDeltaTime);
        Vector3 upRotation = Vector3.right.normalized * - (_verticalRotationSpeed * Time.fixedDeltaTime);
        
        Vector3 resultVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            resultVector = downRotation;
            _rigidbody.AddRelativeTorque(downRotation, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            resultVector = upRotation;
            _rigidbody.AddRelativeTorque(upRotation, ForceMode.Impulse);
        }

        return resultVector;
    }

    public void DestroyPlayer()
    {
        _camera.parent = null;
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
