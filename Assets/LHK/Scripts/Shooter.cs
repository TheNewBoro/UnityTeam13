using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] float attackSpeed;

    
    
    

    [Range(10, 30)]
    [SerializeField] float bulletSpeed;

    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);

            Rigidbody bulletRigidBody = instance.GetComponent<Rigidbody>();
            bulletRigidBody.velocity = muzzlePoint.forward * bulletSpeed;

        }

    }

   //public void ShowEffect()
   //{
   //    PooledObject instance = 
   //    // bullet이 ReturnPool할때
   //
   //    // ShellExplosion 프리팹을 bullet의 위치에 구현하고 즉시 사라지게한다
   //}
}
