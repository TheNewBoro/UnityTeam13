using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmSource;
    public AudioClip titleBGM;
    public AudioClip gameBGM;
    public AudioClip LodingBGM;
    public AudioClip GameOverBGM;
    public AudioClip otherBGM; // ����

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // �� �ٲ� �� ȣ�� ���
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBGMForScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGMForScene(scene.name);
    }

    void PlayBGMForScene(string sceneName)
    {
        AudioClip newClip = null;

        switch (sceneName) // ������ BGM ���� ����
        {
            case "Title Scene":
                newClip = titleBGM;
                break;
            case "Loding Scene":
                newClip = LodingBGM;
                break;
            case "MainGame":
                newClip = gameBGM;
                break;
            case "GameOver Scene":
                newClip = GameOverBGM;
                break;
            default:
                newClip = otherBGM;
                break;
        }

        if (bgmSource.clip != newClip)
        {
            bgmSource.clip = newClip;
            bgmSource.Play();
        }
    }
}
