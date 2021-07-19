using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Unit>();
        if (player != null)
        {
            //player.Death();
        }
        Destroy(gameObject);
    }
}
