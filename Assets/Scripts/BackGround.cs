using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float offset = 4f;
    void Update()
    {
        Vector3 pos = Game.playerObj.transform.position;
        pos.x = (int)(pos.x / offset) * offset;
        pos.y = (int)(pos.y / offset) * offset;
        transform.position = pos;
    }
}
