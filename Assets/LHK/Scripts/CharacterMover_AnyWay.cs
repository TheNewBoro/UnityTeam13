using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover_AnyWay : MonoBehaviour
{

    [SerializeField] private float rotateInterpolate;
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float walkSpeed = 1;

    //플레이어 이동속도
    private float moveSpeed;


    private void FixedUpdate()
    {
        SetPosition();
    }
    private void SetPosition()
    {
        Vector3 direction = GetNormalizedDirection();
        if (direction == Vector3.zero)
        {
            return;
        }

        //shift키를 누르는 동안 달리기
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateInterpolate * Time.deltaTime);
        transform.position += moveSpeed * Time.deltaTime * direction;
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");

        return inputDirection.normalized;
    }
}
