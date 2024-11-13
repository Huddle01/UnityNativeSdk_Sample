using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public float speed = 2f;
    public float range = 2f;
    protected Vector3 startPosition;

    
    protected virtual void Start()
    {
        startPosition = transform.position;
    }

    
    protected abstract void Move();

    
    void Update()
    {
        Move();
    }
}

