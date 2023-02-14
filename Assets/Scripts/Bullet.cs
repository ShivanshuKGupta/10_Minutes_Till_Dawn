using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bulletProperties prop = null;
    void Start()
    {

    }
    public void init(bulletProperties _prop)
    {
        prop = _prop;
    }
    void Update()
    {
        if (prop == null) return;
        print("Bullet::Update(): prop.dir = " + prop.dir);
        transform.position += (Vector3)prop.dir * Time.deltaTime * 100;
        prop.dir -= prop.dir / prop.dir.magnitude * prop.friction * Time.deltaTime * 100;
    }
}
