using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material main;
    [SerializeField] private Material dead;

    private SkinnedMeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Death()
    {
        meshRenderer.materials = new Material[1] { dead };
    }
}
