using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveForwardBackward : Obstacle
{
    protected override void Move()
    {
        // Move forward and backward using a sine wave for smooth movement
        Vector3 newPosition = startPosition;
        newPosition.z += Mathf.Sin(Time.time * speed) * range;
        transform.position = newPosition;
    }
}
