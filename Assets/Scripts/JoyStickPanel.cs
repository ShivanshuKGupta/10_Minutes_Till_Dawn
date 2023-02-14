using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Transform JoystickBG, JoystickThumb;
    private float radius = 1f;
    public Vector2 dir { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if ((JoystickBG = transform.Find("JoystickBG")) == null)
            print("Cannot Find JoyStickBG GameObject");
        if ((JoystickThumb = JoystickBG.transform.Find("Thumb")) == null)
            print("Cannot Find Thumb GameObject");
        JoystickBG.gameObject.SetActive(false);
    }
    Vector2 startPos, bgPos, thumbPos;
    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        JoystickBG.gameObject.SetActive(true);
        thumbPos = bgPos = Camera.main.ScreenToWorldPoint(startPos);
        dir = Vector2.zero;
        JoystickBG.transform.position = bgPos;
        JoystickThumb.transform.position = thumbPos;
        OnDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        bgPos = Camera.main.ScreenToWorldPoint(startPos);
        Vector2 pos = Camera.main.ScreenToWorldPoint(eventData.position);
        dir = pos - bgPos;
        dir = (dir.magnitude < radius ? dir : radius * dir / dir.magnitude);
        thumbPos = bgPos + dir;
        JoystickBG.transform.position = bgPos;
        JoystickThumb.transform.position = thumbPos;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        dir = Vector2.zero;
        thumbPos = startPos;
        JoystickBG.transform.position = bgPos;
        JoystickThumb.transform.position = thumbPos;
        JoystickBG.gameObject.SetActive(false);
    }

    public bool isActive()
    {
        return dir.magnitude != 0;
    }
}
