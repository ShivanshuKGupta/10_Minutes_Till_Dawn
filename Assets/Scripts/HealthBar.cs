using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int _health = 0;
    private int _capacity = 1;
    private List<GameObject> Hearts = new List<GameObject>();
    public int capacity
    {
        get { return _capacity; }
        set
        {
            while (capacity < value)
            {
                addHeart();
                _capacity++;
            }
            while (capacity > value)
            {
                removeHeart();
                _capacity--;
            }
        }
    }
    public int health
    {
        get { return _health; }
        set
        {
            int newVal = value < capacity ? value : capacity;
            while (health < newVal)
            {
                Hearts[_health].GetComponent<Animator>().SetBool("isAlive", true);
                _health++;
            }
            while (health > newVal)
            {
                Hearts[_health - 1].GetComponent<Animator>().SetBool("isAlive", false);
                _health--;
            }
        }
    }
    private GameObject firstHeart;
    // Start is called before the first frame update
    void Start()
    {
        if ((firstHeart = transform.Find("FirstHeart").gameObject) == null) print("Cannot Find First Heart GameObject for HealthBar");
        // firstHeart.GetComponent<Animator>().SetBool("isAlive", true);
        Hearts.Add(firstHeart);
    }
    void addHeart()
    {
        GameObject newHeart = Instantiate(firstHeart);

        newHeart.transform.SetParent(transform);

        newHeart.transform.localScale = firstHeart.transform.localScale;

        Vector3 pos = firstHeart.transform.localPosition;
        pos.x += firstHeart.transform.localPosition.x * 2 * capacity;
        newHeart.transform.localPosition = pos;

        Hearts.Add(newHeart);
    }
    void removeHeart()
    {
        GameObject lastHeart = Hearts[Hearts.Count - 1];
        Destroy(lastHeart);
        Hearts.RemoveAt(Hearts.Count - 1);
    }
}
