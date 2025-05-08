using System.Collections;
using UnityEngine;
using UnityEngine.Audio; // AudioMixerGroup을 위해 필요

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public bool isPenetrating = false;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioMixerGroup sfxMixerGroup; // SFX 믹서 그룹 할당

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        isPenetrating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPenetrating)
        {
            if (other.CompareTag("Monster"))
            {
                PlayHitSound();
                Debug.Log("관통탄이 몬스터와 충돌");
            }
            else if (other.CompareTag("Wall"))
            {
                Debug.Log("관통탄이 벽과 충돌");
                PlayHitSound();
                Destroy(gameObject);
            }

            return;
        }

        if (other.CompareTag("Monster") || other.CompareTag("Wall"))
        {
            Debug.Log("일반탄이 몬스터 또는 벽과 충돌");
            PlayHitSound();
            Destroy(gameObject);
        }
    }

    private void PlayHitSound()
    {
        if (hitSound != null && GameManager.Instance.Player != null)
        {
            GameObject soundObj = new GameObject("HitSound");
            soundObj.transform.position = GameManager.Instance.Player.transform.position;

            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = sfxMixerGroup; // ★ 여기서 믹서 그룹 지정
            source.clip = hitSound;
            source.volume = 1.0f;
            source.spatialBlend = 0f; // 2D 사운드
            source.Play();

            Destroy(soundObj, hitSound.length);
        }
    }
}