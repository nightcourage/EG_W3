using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlaneControl player = collision.gameObject.GetComponent<PlaneControl>();
        if (player)
        {
            player.DestroyPlayer();
        }
    }
}
