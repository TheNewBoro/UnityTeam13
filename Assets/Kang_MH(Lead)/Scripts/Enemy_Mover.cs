using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Mover : MonoBehaviour
{
    public int attackDamage = 1;
    public float attackCooldown = 1f;

    private Transform player;
    private NavMeshAgent agent;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindWithTag("player")?.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;
        agent.SetDestination(player.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && Time.time - lastAttackTime >= attackCooldown)
        {
            playerHealth playerHealth = other.GetComponent<playerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
            }
        }
    }
}
