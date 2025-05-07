using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpTest : MonoBehaviour
{
    public int playerHP = 1; // �⺻ ü��
    public int currentHP; // ���� ü��
    public float playerSize = 1f; // ũ�� ����
    public float sizeIncrement = 1f; // ũ�� ������
    public float sizeDecrement = 1f; // ũ�� ���ҷ�
    public float maxPlayerHP = 2f; // �ִ� ü�� ����
    public float maxPlayerSize = 2f;
    private bool canGrow = true; // ũ�� ���� ���� ����

    void Start()
    {
        currentHP = playerHP;
        UpdateSize();
    }


        // ũ�� ������Ʈ �Լ�
        void UpdateSize()
    {
        transform.localScale = Vector3.one * playerSize;
    }

    // ������ �Ա� �� ȣ��
    public void Grow()
    {
        if (canGrow && playerSize < maxPlayerSize)
        {
            playerSize += sizeIncrement;
            if (playerSize > maxPlayerSize)
            {
                playerSize = maxPlayerSize; // �ִ� ũ�� ����
            }
            currentHP += 1;
            UpdateSize();

            // ũ�� �ִ뿡 ���������� �� �̻� Ŀ���� ����
            if (playerSize >= maxPlayerSize)
            {
                canGrow = false;
            }
        }
    }

    // �ǰ� �� ȣ��
    public void TakeDamage()
    {
        currentHP -= 1;
        if (currentHP <= 0)
        {
            // ��� ó�� (��: ���� ����)
            Debug.Log("���� ����");
        }
        else
        {
            // ũ�� ���̱�
            playerSize -= sizeDecrement;
            if (playerSize < 1f)
            {
                playerSize = 1f; // �ּ� ũ��
            }
            UpdateSize();

            // ũ�Ⱑ ���� ũ�⺸�� �۾������� üũ, �ٽ� ������ �Ծ� ũ�� Ŀ�� �� ����
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
