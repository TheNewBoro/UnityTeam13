using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mover : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float stopDistance = 2f;
    // Start is called before the first frame update

    private Transform player;
    private Rigidbody target;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            target.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }
}

