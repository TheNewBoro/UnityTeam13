using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVmanager : MonoBehaviour
{
    public RawImage cctvDisPlay;    // CCTV ȭ���� ����� UI �̹���
    public RenderTexture[] cctvTextures;  // �� CCTV ī�޶��� �����ؽ��� �迭

    private void Update()
    {
        // ���� 1 Ű�� �����µ��� CCTV1 ȭ�� ���
        if(Input.GetKey(KeyCode.Alpha1))
        {
            cctvDisPlay.texture = cctvTextures[0];   // CCTV1 ȭ�� ����
            cctvDisPlay.enabled = true;              // ȭ�� ���̰� ����
        }

        //���� 2 Ű�� ������ ���� CCTV2 ȭ�� ���

        else if (Input.GetKey(KeyCode.Alpha2))
        {
            cctvDisPlay.texture = cctvTextures[1];   //CCTV2 ȭ�� ����
            cctvDisPlay.enabled = true;              //ȭ�� ���̰� ����
        }

        else
        {
            cctvDisPlay.enabled = false;             // �ƹ�Ű�� �ȴ����� CCTV ȭ�� ����
        }
    }
}
