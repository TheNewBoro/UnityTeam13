using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1f; // ������ �ð� �ٽ� �簳
        SceneManager.LoadScene("Title Scene"); // �� �̸��� �°� ����
    }
}