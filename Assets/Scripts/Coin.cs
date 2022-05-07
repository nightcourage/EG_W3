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

    private void OnCollisionEnter(Collision collision)
    {
        PlaneControl player = collision.gameObject.GetComponent<PlaneControl>();
        if (player)
        {
            DestroyCoin();
        }
    }

    private void DestroyCoin()
    {
        GetComponentInParent<ObjectSpawner>().ObjectListUpdate(transform.gameObject);
        Destroy(gameObject);
    }
}
