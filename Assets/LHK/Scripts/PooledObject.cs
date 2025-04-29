using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool returnPool;
    [SerializeField] float returnTime;
    private float timer;

    private void OnEnable()
    {
        timer = returnTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ReturnPool(); //Ÿ�̸Ӱ� ������ Ǯ�� ���ư�.
        }
    }

    public void ReturnPool()
    {

        if (returnPool == null)
        {
            Destroy(gameObject);  //���ư����� ������ �����.
        }
        else
        {
            returnPool.ReturnPool(this);
        }

    }
}
