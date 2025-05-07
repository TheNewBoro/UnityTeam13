using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    //플레이어 체력
    

    public int playerLevel = 1;
    public int experience = 0;
    public int experienceToLevelUp =6 ;

    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    public int playerHP = 1; // 기본 체력
    public int currentHP; // 현재 체력
    public float playerSize = 1f; // 크기 배율
    public float sizeIncrement = 1f; // 크기 증가량
    public float sizeDecrement = 1f; // 크기 감소량
    public float maxPlayerHP = 2f; // 최대 체력 제한
    public float maxPlayerSize = 2f;
    private bool canGrow = true; // 크기 증가 가능 여부
    void Start()
    {
        currentHP = playerHP;
        UpdateSize();
    }

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


    public void Grow()
    {
        if (canGrow && playerSize < maxPlayerSize)
        {
            playerSize += sizeIncrement;
            if (playerSize > maxPlayerSize)
            {
                playerSize = maxPlayerSize; // 최대 크기 제한
            }
            currentHP += 1;
            UpdateSize();

            // 크기 최대에 도달했으면 더 이상 커지지 않음
            if (playerSize >= maxPlayerSize)
            {
                canGrow = false;
            }
        }
    }


    void UpdateSize()
    {
        transform.localScale = Vector3.one * playerSize;
    }


    public void TakeDamage()
    {
        currentHP -= 1;
        if (currentHP <= 0)
        {
            // 사망 처리 (예: 게임 오버)
            Debug.Log("게임 오버");
        }
        else
        {
            // 크기 줄이기
            playerSize -= sizeDecrement;
            if (playerSize < 1f)
            {
                playerSize = 1f; // 최소 크기
            }
            UpdateSize();

            // 크기가 원래 크기보다 작아졌는지 체크, 다시 아이템 먹어 크기 커질 수 있음
        }
        if (playerSize < maxPlayerSize)
        {
            canGrow = true;
        }
        else
        {
            canGrow = false;
        }
    }
}
