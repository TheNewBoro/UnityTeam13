using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("ProtoType"); // 어떤 씬 으로 이동할건지
    }

}