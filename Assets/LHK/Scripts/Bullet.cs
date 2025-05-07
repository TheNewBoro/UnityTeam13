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
        // 관통탄인 경우
        if (isPenetrating)
        {
            if (other.CompareTag("Monster"))
            {
                // 몬스터와 충돌
                PlayHitSound();
                Debug.Log("관통탄이 몬스터와 충돌");
            }
            else if (other.CompareTag("Wall"))
            {
                Debug.Log("관통탄이 벽과 충돌");
                // 벽과 충돌
                PlayHitSound();
                Destroy(gameObject);  // 벽에 닿으면 총알 파괴
            }

            return;  // 관통탄인 경우 여기서 처리 끝내고 빠져나옴
        }

        // 관통이 아닌 경우
        if (other.CompareTag("Monster") || other.CompareTag("Wall"))
        {
            Debug.Log("일반탄이 몬스터 또는 벽과 충돌");
            // 몬스터 또는 벽과 충돌
            PlayHitSound();
            Destroy(gameObject);  // 충돌 후 총알 파괴
        }
    }

    // 피격 사운드를 재생하는 함수
    private void PlayHitSound()
    {
        if (hitSound != null && GameManager.Instance.Player != null)
        {
            // 플레이어 위치 기준으로 사운드 객체 생성
            GameObject soundObj = new GameObject("HitSound");
            soundObj.transform.position = GameManager.Instance.Player.transform.position;

            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = hitSound;
            source.volume = 1.0f;
            source.spatialBlend = 0f; // 2D 사운드로 처리
            source.Play();

            Destroy(soundObj, hitSound.length);
        }
    }
}
