using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProperties
{
    /// <summary>
    /// The size of the bullet in terms of scale [default = 5]
    /// </summary>
    public float size = 5f;
    /// <summary>
    /// The range of the bullet (the maximum distance it can travel)
    /// </summary>
    public float range = 1f;
    public bool canExplode = false;
    /// <summary>
    /// How many times the bullet can bounce before being destroyed
    /// </summary>
    public int bounce = 0;
    /// <summary>
    /// How many enemies can the bullet pierce before being destroyed or bounced off an enemy
    /// </summary>
    public int pierce = 0;
    /// <summary>
    /// A Vector2 variable containing the speed and direction of the bullet
    /// </summary>
    public Vector2 dir = new Vector2(0, 0);
    /// <summary>
    /// The velocity that the bullet should lose in every interval
    /// </summary>
    public float friction = 0.01f;
}