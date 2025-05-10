using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동속도
    public float rotateSpeed = 100f; //회전속도
    public Camera playerCamera;  // 플레이어 시점 카메라 (1인칭)

    private void Update()
    {
        // w나 s의 입력값으로 전후 이동
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * move); // 전후 이동

        // a나 d 의 입력으로 좌우 회전
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotate); // 좌우 회전
    }
}
