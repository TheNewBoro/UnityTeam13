using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public bool isPenetrating = false;

    [SerializeField] private AudioClip hitSound;
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
        // ����ź�� ���
        if (isPenetrating)
        {
            if (other.CompareTag("Monster"))
            {
                // ���Ϳ� �浹
                PlayHitSound();
                Debug.Log("����ź�� ���Ϳ� �浹");
            }
            else if (other.CompareTag("Wall"))
            {
                Debug.Log("����ź�� ���� �浹");
                // ���� �浹
                PlayHitSound();
                Destroy(gameObject);  // ���� ������ �Ѿ� �ı�
            }

            return;  // ����ź�� ��� ���⼭ ó�� ������ ��������
        }

        // ������ �ƴ� ���
        if (other.CompareTag("Monster") || other.CompareTag("Wall"))
        {
            Debug.Log("�Ϲ�ź�� ���� �Ǵ� ���� �浹");
            // ���� �Ǵ� ���� �浹
            PlayHitSound();
            Destroy(gameObject);  // �浹 �� �Ѿ� �ı�
        }
    }

    // �ǰ� ���带 ����ϴ� �Լ�
    private void PlayHitSound()
    {
        if (hitSound != null && GameManager.Instance.Player != null)
        {
            // �÷��̾� ��ġ �������� ���� ��ü ����
            GameObject soundObj = new GameObject("HitSound");
            soundObj.transform.position = GameManager.Instance.Player.transform.position;

            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = hitSound;
            source.volume = 1.0f;
            source.spatialBlend = 0f; // 2D ����� ó��
            source.Play();

            Destroy(soundObj, hitSound.length);
        }
    }
}
