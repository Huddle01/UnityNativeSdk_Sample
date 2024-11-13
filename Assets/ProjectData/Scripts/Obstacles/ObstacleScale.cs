using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScale : Obstacle
{
    protected override void Move()
    {
        // Scale the object between 0 and 1 using a sine wave
        float scaleValue = (Mathf.Sin(Time.time * speed) + 1) / 2; // Normalize between 0 and 1
        transform.localScale = Vector3.one * scaleValue;
    }
}
