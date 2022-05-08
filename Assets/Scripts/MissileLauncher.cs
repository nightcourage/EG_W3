using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _missile;
    [SerializeField] private float _distance;
    private GameObject _target;
    private Transform _playerTransform;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _target.transform;
    }

    private void Update()
    {
        float currentDistace = Vector3.Distance(_playerTransform.position, transform.position);
        
        
        if (currentDistace <= _distance)
        {
            LaunchMissile();
        }
    }

    private void LaunchMissile()
    {
        Vector3 offset = new Vector3(0f, 10f, 0f);
        Instantiate(_missile, transform.localPosition + offset, Quaternion.identity);
    }
}
