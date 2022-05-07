using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlaneControl player = collision.gameObject.GetComponent<PlaneControl>();
        if (player)
        {
            player.DestroyPlayer();
            Destroy(gameObject);
            GetComponentInParent<ObjectSpawner>().ObjectListUpdate(gameObject);
        }
    }
}
