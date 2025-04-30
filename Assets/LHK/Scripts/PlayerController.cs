using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    //플레이어 체력
    [SerializeField] private float playerHP;

    //플레이어 이동속도
    [SerializeField] private float playerMoveSpeed;
    
    

    private void FixedUpdate()
    { 
        if(fireCoroutine == null) 
        { 
        fireCoroutine = StartCoroutine(shooter.Fire());
        }

    }


    //적 또는 적의 발사체와 충돌하면 hp-1
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            playerHP--;
            Debug.Log("플레이어 체력 -1");
        }

        else if(other.CompareTag("Monster"))
        {
            playerHP--;
            Debug.Log("플레이어 체력 -1");
        }
    }

    
}
