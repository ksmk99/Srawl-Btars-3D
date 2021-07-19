using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    private Transform camera;

    private void Awake()
    {
        camera = Camera.main.transform;
    }

    public void LateUpdate()
    {
        transform.LookAt(camera);
    }
}
