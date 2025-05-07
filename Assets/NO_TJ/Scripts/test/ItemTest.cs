using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("!!!æ∆¿Ã≈€ »πµÊ!!!");
            player.Grow();
            Destroy(gameObject); // æ∆¿Ã≈€ ªÁ∂Û¡¸
        }
    }
}
