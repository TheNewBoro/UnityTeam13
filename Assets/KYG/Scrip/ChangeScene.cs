using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void GameScenesCtrl()
    {
        LodingScene.LoadScene("pause Scene"); // SceneManager.LoadScene("pause Scene"); // � �� ���� �̵��Ұ���
    }

}