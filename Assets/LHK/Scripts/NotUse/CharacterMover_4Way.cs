using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover_4Way : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.forward;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.back;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (direction != Vector3.zero)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
