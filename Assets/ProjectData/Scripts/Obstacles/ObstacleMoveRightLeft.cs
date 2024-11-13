using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveRightLeft : Obstacle
{
    protected override void Move()
    {
        Vector3 newPosition = startPosition;
        newPosition.x += Mathf.Sin(Time.time * speed) * range;
        transform.position = newPosition;
    }
}
