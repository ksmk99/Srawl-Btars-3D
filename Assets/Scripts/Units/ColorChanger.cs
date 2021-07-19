using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material DeathMaterial;

    private SkinnedMeshRenderer meshRenderer;
    private Material[] deathMats;

    public void Start()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        deathMats = new Material[1] { DeathMaterial };

        GetComponent<Health>().OnDeath += () => meshRenderer.materials = deathMats;
    }
}
