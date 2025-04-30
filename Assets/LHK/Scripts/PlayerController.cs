using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    private Coroutine fireCoroutine;

    private void FixedUpdate()
    { 
        if(fireCoroutine == null) 
        { 
        fireCoroutine = StartCoroutine(shooter.Fire());
        }

    }
}
