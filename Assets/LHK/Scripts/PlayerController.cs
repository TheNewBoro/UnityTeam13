using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    //�÷��̾� ü��
    [SerializeField] private float playerHP;

    //�÷��̾� �̵��ӵ�
    [SerializeField] private float playerMoveSpeed;
    
    

    private void FixedUpdate()
    { 
        if(fireCoroutine == null) 
        { 
        fireCoroutine = StartCoroutine(shooter.Fire());
        }

    }


    //�� �Ǵ� ���� �߻�ü�� �浹�ϸ� hp-1
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            playerHP--;
            Debug.Log("�÷��̾� ü�� -1");
        }

        else if(other.CompareTag("Monster"))
        {
            playerHP--;
            Debug.Log("�÷��̾� ü�� -1");
        }
    }

    
}
