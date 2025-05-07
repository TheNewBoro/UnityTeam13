using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    //�÷��̾� ü��
    

    public int playerLevel = 1;
    public int experience = 0;
    public int experienceToLevelUp =6 ;

    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

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

    private void Update()
    { 
        if(fireCoroutine == null) 
        { 
        fireCoroutine = StartCoroutine(shooter.Fire());
        }

        if (playerHP <=0)
        {
            Debug.Log("<color=#ff0000ff>�÷��̾� ���</color>");
            //TODO ���ӿ���
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

    


    //�� �Ǵ� ���� �߻�ü�� �浹�ϸ� hp-1
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Monster"))
        {
            playerHP--;
            Debug.Log("<color=#ff0000ff>���Ϳ� �浹�Ͽ� �÷��̾� ü�� -1</color>");
        }
    }

    

    public void GainExperience(int amount)
    {
        experience += amount;
        Debug.Log($"����ġ ȹ��: +{amount} ���� ����ġ: {experience}/{experienceToLevelUp}");

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

        Debug.Log($"<b>!!!!���� {playerLevel} �޼�!!!!</b>, ���� ����ġ: {experience}, ���� ��������: {experienceToLevelUp}");

    }


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


    void UpdateSize()
    {
        transform.localScale = Vector3.one * playerSize;
    }


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
