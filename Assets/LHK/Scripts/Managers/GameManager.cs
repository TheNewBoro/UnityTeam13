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
            Debug.Log($"{gameObject.name} �̱��� ����");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log($"�ߺ��� {gameObject.name} ���ӸŴ��� ����");
            Destroy(gameObject);
        }
    }

    

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"{amount} ���� ȹ��");
    }


}
