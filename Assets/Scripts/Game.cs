using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A static class containing all info about the game objects, scripts etc.
/// Can serve as the medium of communication between different components of the game
/// (Working like the storage house of the game)
/// </summary>
public class Game : MonoBehaviour
{
    static public GameObject playerObj { get; private set; }
    static public GameManager gameManager { get; private set; }
    static public Player player { get; private set; }
    static public JoyStickPanel joyStick { get; private set; }
    static public JoyStickPanel joyStickShoot { get; private set; }
    static public HealthBar healthBar { get; private set; }
    static public LevelBar levelBar { get; private set; }
    static public Gun gun { get; private set; }
    private void Start()
    {
        if ((playerObj = GameObject.Find("Player")) == null)
            print("Game Object with name 'Player' Not Found");
        if ((player = GameObject.Find("Player").GetComponent<Player>()) == null)
            print("Player Script Not Found Attached to GameObject Player");
        if ((gameManager = GameObject.Find("GameManager").GetComponent<GameManager>()) == null)
            print("Error Getting Reference to GameManager Script Attached to the GameObject 'GameManager'");
        if ((joyStick = GameObject.Find("JoyStickPanel").GetComponent<JoyStickPanel>()) == null)
            print("Error Getting Reference to JoyStickPanel Script Attached to the GameObject 'JoyStickPanel'");
        if ((joyStickShoot = GameObject.Find("ShootPanel").GetComponent<JoyStickPanel>()) == null)
            print("Error Getting Reference to JoyStickPanel Script Attached to the GameObject 'ShhotPanel'");
        if ((healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>()) == null)
            print("Error Getting Reference to HealthBar Script Attached to the GameObject 'HealthBar'");
        if ((levelBar = GameObject.Find("LevelBar").GetComponent<LevelBar>()) == null)
            print("Error Getting Reference to LevelBar Script Attached to the GameObject 'LevelBar'");
        if ((gun = GameObject.Find("Gun").GetComponent<Gun>()) == null)
            print("Error Getting Reference to Gun Script Attached to the GameObject 'Gun'");
    }
}
