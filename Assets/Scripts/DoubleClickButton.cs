using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleClickButton : MonoBehaviour, IPointerClickHandler
{
    public Action OnSingleClick;
    public Action OnDoubleClick;

    private float lastClick = 0f;
    private float interval = 0.5f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time && OnDoubleClick != null)
            OnDoubleClick();
        else if (OnSingleClick != null)
            OnSingleClick();

        lastClick = Time.time;
    }
}
