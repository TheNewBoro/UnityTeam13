using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    [SerializeField] PooledObject prefab; 
    [SerializeField] int size; //처음 준비할 크기


    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            pool.Add(instance);
        }


    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {

        if (pool.Count == 0)
        {
            return Instantiate(prefab, position, rotation); 
            //총알풀이0이면 발사불가 return null;
        }
        PooledObject instance = pool[pool.Count - 1];
        pool.RemoveAt(pool.Count - 1);

        instance.returnPool = this;
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void ReturnPool(PooledObject instance)
    {
        instance.gameObject.SetActive(false);
        pool.Add(instance);
    }

}
