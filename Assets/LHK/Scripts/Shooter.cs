using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] float attackSpeed;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootSound;



    [Range(10, 30)]
    [SerializeField] float bulletSpeed;

    private bool canPenetrate = false;

    

    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);

            
            Rigidbody bulletRigidBody = instance.GetComponent<Rigidbody>();
            bulletRigidBody.velocity = muzzlePoint.forward * bulletSpeed;
            


            //관통탄 설정
            Bullet bullet = instance.GetComponent<Bullet>();
            bullet.isPenetrating = canPenetrate;


            //발사 사운드 설정
            if (audioSource != null && shootSound != null)
            
                audioSource.PlayOneShot(shootSound);
            
            


        }
    }

    public void EnablePenetration(bool isEnabled)
    {
        canPenetrate = isEnabled;
    }

   

   
}
