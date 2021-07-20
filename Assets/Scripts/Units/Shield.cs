using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int activeTime = 7;

    private CapsuleCollider collider;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        collider = GetComponent<CapsuleCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Activate()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
        StartCoroutine(Deatcivate());
    }

    private IEnumerator Deatcivate()
    {
        yield return new WaitForSeconds(activeTime);
        collider.enabled = false;
        meshRenderer.enabled = false;
    }
}
