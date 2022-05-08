using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private int _missileSpeed;
    [SerializeField] private float _rotationSpeed;
    
    private Transform _targetPosition;

    private void Start()
    {
        _target.GetComponent<PlaneControl>();
        _targetPosition = _target.transform;
    }

    private void Update()
    {
        FollowTarget();
    }
    

    private void FollowTarget()
    {
        Vector3 direction = _targetPosition.localPosition - transform.position;
        transform.position = direction * (_missileSpeed * Time.deltaTime);
        
        Quaternion followRotation = Quaternion.LookRotation(direction);
        Vector3 missileRotation = Quaternion.Lerp(transform.localRotation, followRotation, _rotationSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0, missileRotation.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlaneControl plane = collision.gameObject.GetComponent<PlaneControl>();
        if (plane)
        {
            Debug.Log("Hit plane");
            // plane.DestroyPlayer();
        }
    }
}
