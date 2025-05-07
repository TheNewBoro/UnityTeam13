using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerHpTest player = other.GetComponent<PlayerHpTest>();
        if (player != null)
        {
            player.Grow();
            Destroy(gameObject); // 아이템 사라짐
        }
    }
}
