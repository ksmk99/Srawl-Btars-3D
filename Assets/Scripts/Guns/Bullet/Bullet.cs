using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 20f;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected float timeToDestroy = 1f;

    protected GameObject parent;

    public void SetParent(GameObject parent) => this.parent = parent;

    protected virtual void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    protected virtual void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    protected abstract void OnTriggerEnter(Collider other);
}