using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AButton : MonoBehaviour, /*IPointerUpHandler,*/ IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //only used if called on button on click in unity inspector
    public void PressA()
    {
        Pressed = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Pressed = false;
    //}
}