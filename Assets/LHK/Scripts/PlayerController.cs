using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooter.Fire();
        }
    }
}
