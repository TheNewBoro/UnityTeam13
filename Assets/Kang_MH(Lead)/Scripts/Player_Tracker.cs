using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tracker : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    [SerializeField] private float detectedRadius;
    // Todo: 나중에 지우고 변경 맵 오브젝트가 열렸을 때 감지하게 끔 수정 및 사거리 안에 들어왔을 때 멈추게 끔 변경
    [SerializeField] private LayerMask target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectedTarget();
    }


    private void DetectedTarget()
    {
        if(Physics.OverlapSphere(transform.position, detectedRadius, target).Length > 0)
        { 
        
        }
        else
        {
            EnemyRotate();
        }
    }
    
    private void EnemyRotate()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectedRadius);
    }

}
