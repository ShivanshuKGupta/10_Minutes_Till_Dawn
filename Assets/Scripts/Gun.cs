using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bulletProperties prop;
    private float radius = 0.25f;
    [SerializeField]
    private GameObject bulletPreFab;
    public bool isShooting { get; private set; }
    void Start()
    {
        isShooting = false;
    }
    IEnumerator shooting()
    {
        isShooting = true;
        GameObject newBulletObj = Instantiate(bulletPreFab);
        newBulletObj.transform.position = transform.position;
        Bullet newBullet = newBulletObj.GetComponent<Bullet>();
        print("prop.dir.magnitude = " + prop.dir.magnitude);
        prop.dir = oldDir * (prop.dir.magnitude / oldDir.magnitude);
        print("Pasing prop.dir = " + prop.dir + "to a new bullet");
        newBullet.init(prop);
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }
    /// <summary>
    /// Directs the gun towards the nearest enemy
    /// </summary>
    void autoDirect()
    {
        Vector2 dir = Game.joyStickShoot.dir;
        if (dir.magnitude < 0.1)
        {
            // find the nearest target
            // get the required direction and change dir
        }
        direct(dir);
    }
    private Vector2 oldDir = new Vector2(1, 0);
    /// <summary>
    /// Directs the gun in the direction 'dir'
    /// </summary>
    /// <param name="dir">The Direction to point the gun towards</param>
    void direct(Vector2 dir)
    {
        if (dir.magnitude <= 0.001f)
            dir = oldDir;
        GetComponent<SpriteRenderer>().flipY = (dir.x < 0);
        float angle = Mathf.Atan2(dir.y, dir.x);
        angle = 180 / Mathf.PI * angle; // conversion to degree
        transform.eulerAngles = new Vector3(0, 0, angle);
        Vector2 pos = Game.player.transform.position;
        pos += dir * radius / dir.magnitude;
        transform.position = pos;
        oldDir = dir;
    }
    void Update()
    {
        autoDirect();
        if (Game.joyStickShoot.isActive() && !isShooting)
        {
            StartCoroutine(shooting());
        }
    }
}
