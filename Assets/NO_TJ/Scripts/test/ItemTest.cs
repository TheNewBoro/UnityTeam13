using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);


        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Grow();
            Destroy(gameObject); // 아이템 사라짐
        }
    }
}
