using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerClickHandler
{
    public Action OnTap = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnTap != null)
        {
            OnTap.Invoke();
        }
    }
}
