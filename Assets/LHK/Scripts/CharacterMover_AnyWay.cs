using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover_AnyWay : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateInterpolate;


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
