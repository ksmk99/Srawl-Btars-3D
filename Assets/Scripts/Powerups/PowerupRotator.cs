using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PowerupRotator : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()    
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.angularVelocity = new Vector3(0, 5, 0);
    }
}
