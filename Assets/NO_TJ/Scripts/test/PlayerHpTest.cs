using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpTest : MonoBehaviour
{
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


        // 크기 업데이트 함수
        void UpdateSize()
    {
        transform.localScale = Vector3.one * playerSize;
    }

    // 아이템 먹기 시 호출
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

    // 피격 시 호출
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
