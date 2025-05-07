using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    //�÷��̾� ü��
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
        // �ڽ��� �� �Ҹ��� �¾� ü���� �����ϴ� ���� ���Ÿ� ���� �ּ�ó��
        //if (other.CompareTag("Bullet"))
        //{
        //    playerHP--;
        //    Debug.Log("<color=#ff0000ff>���Ϳ� �浹�Ͽ� �÷��̾� ü�� -1</color>");
        //}

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

}
