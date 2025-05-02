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
                Debug.Log("���Ϳ� �Ѿ��� �浹������ �����ؼ� ���ư�");

            return;
            
        }
        if (other.gameObject.layer == 6 || other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
