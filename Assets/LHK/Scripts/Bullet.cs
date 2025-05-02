using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public bool isPenetrating = false;
    private void OnEnable()
    {
        isPenetrating = false;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (isPenetrating)
        {
            if (other.CompareTag("Monster"))
                Debug.Log("몬스터와 총알이 충돌했지만 관통해서 날아감");

            return;
            
        }
        if (other.gameObject.layer == 6 || other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
