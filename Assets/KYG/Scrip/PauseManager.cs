using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject menuSet;       // �Ͻ����� �޴�
    public GameObject optionPanel;   // �ɼ�â (Inspector�� �Ҵ� �ʿ�)

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }
    }

    public void OpenPauseMenu()
    {
        isPaused = true;
        Time.timeScale = 0f; // ���� ����
        menuSet.SetActive(true);
        optionPanel.SetActive(false); // �ɼ�â�� �⺻������ ����
    }

    public void ClosePauseMenu()
    {
        isPaused = false;
        Time.timeScale = 1f; // ���� �簳
        menuSet.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void OpenOption()
    {
        Debug.Log("OpenOption() called");
        optionPanel.SetActive(true);
        menuSet.SetActive(false);
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
        menuSet.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}