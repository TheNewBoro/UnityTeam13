using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource bgm;
    public int Length { get; }
    // Start is called before the first frame update


      
        private void Awake()
    {
        var SoundManagers = FindObjectOfType<SoundManager>();
        if (SoundManagers.Length == 0)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        bgm.Play();
    }
}
