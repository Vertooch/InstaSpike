using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTab : MonoBehaviour
{
    [SerializeField] private Image tabImage;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;

    public void SetOn(bool isOn)
    {
        tabImage.color = isOn ? onColor : offColor;
    }
}
