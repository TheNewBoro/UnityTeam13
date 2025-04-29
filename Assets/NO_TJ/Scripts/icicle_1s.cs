using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicle_1s : MonoBehaviour
{
    public float damage; // ������
    public int per; // ����

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if(per > -1)
        {
            rigid.velocity = dir;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
