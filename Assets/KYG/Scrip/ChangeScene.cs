using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void GameScenesCtrl()
    {
        LodingScene.LoadScene("MainGame"); // SceneManager.LoadScene("pause Scene"); // � �� ���� �̵��Ұ���
    }

}