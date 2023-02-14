using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private void Start()
    {
        speed = 0.2f;
    }
    void Update()
    {
        float multiplier = Time.deltaTime * 10f * speed;
        Vector2 speedVector = Game.joyStick.dir * multiplier;
        // Changing face direction according to movement direction
        if (speedVector.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (speedVector.x > 0)
            GetComponent<SpriteRenderer>().flipX = false;

        int animMode = Game.joyStick.dir.magnitude != 0 ? (Game.joyStick.dir.magnitude > 0.5 ? 2 : 1) : 0;
        GetComponent<Animator>().SetInteger("PlayerAnimationState", animMode);

        transform.position += new Vector3(speedVector.x, speedVector.y, 0);

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }
}
