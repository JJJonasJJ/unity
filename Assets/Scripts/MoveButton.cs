using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
       //tror denna script är oanvänd men jag vill inte riskera att ha sönder allt just nu
    public static bool IsPressed
    {
        get;
        set;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("testaa");
        IsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("dd");
        IsPressed = false; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPressed = false;
    }
}
