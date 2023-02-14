using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Game.healthBar.health = Game.healthBar.capacity = 3;
        Game.levelBar.maxValue = 100;
        Game.levelBar.value = 0;
        Game.levelBar.levelNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
