using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
   public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHpTest player = collision.gameObject.GetComponent<PlayerHpTest>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }
}
