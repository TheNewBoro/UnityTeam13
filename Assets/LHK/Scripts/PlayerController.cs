using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    //플레이어 체력
    [SerializeField] private float playerHP=1;

    public int playerLevel = 1;
    public int experience = 0;
    public int experienceToLevelUp =6 ;

    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }



    private void Update()
    { 
        if(fireCoroutine == null) 
        { 
        fireCoroutine = StartCoroutine(shooter.Fire());
        }

        if (playerHP <=0)
        {
            Debug.Log("<color=#ff0000ff>플레이어 사망</color>");
            //TODO 게임오버
        }

        if(playerLevel >= 2)
        {
            shooter.EnablePenetration(true);
        }
        else
        {
            shooter.EnablePenetration(false);
        }
    }

    


    //적 또는 적의 발사체와 충돌하면 hp-1
    private void OnTriggerEnter(Collider other)
    {
        // 자신이 쏜 불릿에 맞아 체력이 감소하는 현상 제거를 위해 주석처리
        //if (other.CompareTag("Bullet"))
        //{
        //    playerHP--;
        //    Debug.Log("<color=#ff0000ff>몬스터와 충돌하여 플레이어 체력 -1</color>");
        //}

        if (other.CompareTag("Monster"))
        {
            playerHP--;
            Debug.Log("<color=#ff0000ff>몬스터와 충돌하여 플레이어 체력 -1</color>");
        }
    }

    

    public void GainExperience(int amount)
    {
        experience += amount;
        Debug.Log($"경험치 획득: +{amount} 현재 경험치: {experience}/{experienceToLevelUp}");

        while (experience >= experienceToLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        experience -= experienceToLevelUp;
        playerLevel++;

        experienceToLevelUp += 5;

        Debug.Log($"<b>!!!!레벨 {playerLevel} 달성!!!!</b>, 현재 경험치: {experience}, 다음 레벨까지: {experienceToLevelUp}");



    }

}
