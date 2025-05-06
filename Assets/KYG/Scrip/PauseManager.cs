using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject menuSet;       // 일시정지 메뉴
    public GameObject optionPanel;   // 옵션창 (Inspector에 할당 필요)

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
        Time.timeScale = 0f; // 게임 정지
        menuSet.SetActive(true);
        optionPanel.SetActive(false); // 옵션창은 기본적으로 닫힘
    }

    public void ClosePauseMenu()
    {
        isPaused = false;
        Time.timeScale = 1f; // 게임 재개
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