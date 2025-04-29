using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ObjectPool bulletPool;

    
    

    [Range(10, 30)]
    [SerializeField] float bulletSpeed;

    public void Fire()
    {
        PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);

        Rigidbody bulletRigidBody = instance.GetComponent<Rigidbody>();
        bulletRigidBody.velocity = muzzlePoint.forward * bulletSpeed;

        

    }

   //public void ShowEffect()
   //{
   //    PooledObject instance = 
   //    // bullet�� ReturnPool�Ҷ�
   //
   //    // ShellExplosion �������� bullet�� ��ġ�� �����ϰ� ��� ��������Ѵ�
   //}
}
