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
            ReturnPool(); //타이머가 지나면 풀로 돌아감.
        }
    }

    public void ReturnPool()
    {

        if (returnPool == null)
        {
            Destroy(gameObject);  //돌아갈곳이 없으면 지운다.
        }
        else
        {
            returnPool.ReturnPool(this);
        }

    }
}
