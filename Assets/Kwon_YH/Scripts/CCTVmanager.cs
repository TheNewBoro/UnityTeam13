using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVmanager : MonoBehaviour
{
    public RawImage cctvDisPlay;    // CCTV 화면을 출력할 UI 이미지
    public RenderTexture[] cctvTextures;  // 각 CCTV 카메라의 랜더텍스쳐 배열

    private void Update()
    {
        // 숫자 1 키를 누르는동안 CCTV1 화면 출력
        if(Input.GetKey(KeyCode.Alpha1))
        {
            cctvDisPlay.texture = cctvTextures[0];   // CCTV1 화면 연결
            cctvDisPlay.enabled = true;              // 화면 보이게 설정
        }

        //숫자 2 키를 누르는 동안 CCTV2 화면 출력

        else if (Input.GetKey(KeyCode.Alpha2))
        {
            cctvDisPlay.texture = cctvTextures[1];   //CCTV2 화면 연결
            cctvDisPlay.enabled = true;              //화면 보이게 설정
        }

        else
        {
            cctvDisPlay.enabled = false;             // 아무키도 안누르면 CCTV 화면 숨김
        }
    }
}
