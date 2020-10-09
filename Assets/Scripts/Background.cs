using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerClickHandler
{
    public static Action OnTap = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnTap.Invoke();
    }
}
