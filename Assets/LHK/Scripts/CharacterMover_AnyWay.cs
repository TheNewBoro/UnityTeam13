using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover_AnyWay : MonoBehaviour
{

    //[SerializeField] private float rotateInterpolate;
    [SerializeField] private float runSpeed = 1.5f;
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 0.1f;

    //플레이어 이동을 rigidbody velocity로 변경
    [SerializeField] private Rigidbody rigid;
    private Vector3 inputVec;

    
    

    private void Start()
    {
        if(rigid == null)
            rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();
        
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigid.velocity = inputVec * moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        if(inputVec != Vector3.zero)
        {
            Quaternion trargetRotation = Quaternion.LookRotation(inputVec);
            transform.rotation = Quaternion.Slerp(transform.rotation, trargetRotation, rotateSpeed);
        }
    }

    private void PlayerInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        inputVec = new Vector3(x, 0, z).normalized;
    }

    
    

    //private void SetPosition()
    //{
    //    Vector3 direction = GetNormalizedDirection();
    //    if (direction == Vector3.zero)
    //    {
    //        return;
    //    }
    //
    //    //shift키를 누르는 동안 달리기
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        moveSpeed = runSpeed;
    //    }
    //    else
    //    {
    //        moveSpeed = walkSpeed;
    //    }
    //
    //
    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateInterpolate * Time.deltaTime);
    //    transform.position += moveSpeed * Time.deltaTime * direction;
    //
    //    //Rigidbody velocity 활용해서 이동하도록 변경
    //}

    //private Vector3 GetNormalizedDirection()
    //{
    //    Vector3 inputDirection = Vector3.zero;
    //    inputDirection.x = Input.GetAxisRaw("Horizontal");
    //    inputDirection.z = Input.GetAxisRaw("Vertical");
    //
    //    return inputDirection.normalized;
    //}
}
