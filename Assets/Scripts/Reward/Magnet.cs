using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float power;

    private void OnTriggerEnter(Collider other)
    {
        var diamond = other.GetComponent<Diamond>();
        if (diamond != null)
        {
            StartCoroutine(DelayAdd(diamond));
        }    
    }

    private IEnumerator DelayAdd(Diamond diamond)
    {
        yield return new WaitForSeconds(0.4f);
        diamond.Collect(transform, power);
    }
}
