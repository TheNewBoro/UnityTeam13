using System.Collections;
using UnityEngine;
using UnityEngine.Audio; // AudioMixerGroup�� ���� �ʿ�

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public bool isPenetrating = false;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioMixerGroup sfxMixerGroup; // SFX �ͼ� �׷� �Ҵ�

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
                Debug.Log("����ź�� ���Ϳ� �浹");
            }
            else if (other.CompareTag("Wall"))
            {
                Debug.Log("����ź�� ���� �浹");
                PlayHitSound();
                Destroy(gameObject);
            }

            return;
        }

        if (other.CompareTag("Monster") || other.CompareTag("Wall"))
        {
            Debug.Log("�Ϲ�ź�� ���� �Ǵ� ���� �浹");
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
            source.outputAudioMixerGroup = sfxMixerGroup; // �� ���⼭ �ͼ� �׷� ����
            source.clip = hitSound;
            source.volume = 1.0f;
            source.spatialBlend = 0f; // 2D ����
            source.Play();

            Destroy(soundObj, hitSound.length);
        }
    }
}