using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5f; // 이동 속도

        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); // A(-1) <-> D(+1)
            float vertical = Input.GetAxisRaw("Vertical");     // S(-1) <-> W(+1)

            Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
