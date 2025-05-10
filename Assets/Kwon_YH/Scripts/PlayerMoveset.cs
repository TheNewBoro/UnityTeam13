using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵��ӵ�
    public float rotateSpeed = 100f; //ȸ���ӵ�
    public Camera playerCamera;  // �÷��̾� ���� ī�޶� (1��Ī)

    private void Update()
    {
        // w�� s�� �Է°����� ���� �̵�
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * move); // ���� �̵�

        // a�� d �� �Է����� �¿� ȸ��
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotate); // �¿� ȸ��
    }
}
