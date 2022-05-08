using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed = 10;
    private void Update()
    {
        ChangeTransform();
    }

    private void ChangeTransform()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        PlaneControl plane = other.GetComponentInParent<PlaneControl>();
        if (plane)
        {
            DestroyCoin();
        }
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
        GetComponentInParent<ObjectSpawner>().ObjectListUpdate(gameObject);
    }
}
