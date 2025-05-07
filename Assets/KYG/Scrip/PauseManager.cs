using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 0f;
        menuSet.SetActive(true);
        optionPanel.SetActive(false);
    }

    public void ClosePauseMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menuSet.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GoToTitle()
    {
        Time.timeScale = 1f; // 정지된 시간 다시 재개
        SceneManager.LoadScene("Title Scene"); // 씬 이름에 맞게 변경
    }
}