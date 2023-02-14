using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    private Slider slider;
    private Text levelText;
    public int maxValue
    {
        get { return (int)slider.maxValue; }
        set { slider.maxValue = value; }
    }
    public int value
    {
        get { return (int)slider.value; }
        set
        {
            if (value >= maxValue)
                levelNumber++;
            slider.value = value;
        }
    }
    private int _lvl = 1;
    public int levelNumber
    {
        get { return _lvl; }
        set
        {
            _lvl = value;
            levelText.text = "Level "+ _lvl.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }
}
