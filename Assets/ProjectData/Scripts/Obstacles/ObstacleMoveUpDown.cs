using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveUpDown : Obstacle
{
    protected override void Move()
    {
        // Move up and down using a sine wave for smooth movement
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * speed) * range;
        transform.position = newPosition;
    }
}
