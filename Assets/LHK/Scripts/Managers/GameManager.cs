using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int score;
    public int playerLevel;
    
   
    

    private void Awake()
    {
        CreateInstance();
    }

    private void Update()
    {
        
    }

    private void CreateInstance()
    {
        if (instance == null)
        {
            Debug.Log($"{gameObject.name} 싱글톤 생성");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log($"중복된 {gameObject.name} 게임매니저 삭제");
            Destroy(gameObject);
        }
    }

    

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"{amount} 점수 획득");
    }

    public void AddPlayerLevel(int amount)
    {
        playerLevel += amount;
        Debug.Log($"플레이어 레벨 {amount} 증가");
    }

}
