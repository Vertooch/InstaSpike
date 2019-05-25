using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LargeImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text captionText;

    public void Setup(Sprite displaySprite, string imageCaption)
    {
        DoubleClickButton button = gameObject.GetComponent<DoubleClickButton>();
        button.OnSingleClick += DismissImage;

        image.sprite = displaySprite;

        if (imageCaption != null)
        {
            int captionLength = Mathf.Min(imageCaption.Length, 200);
            string suffix = imageCaption.Length > 200 ? "..." : "";
            captionText.text = imageCaption.Substring(0, captionLength) + suffix;
        }
    }

    private void DismissImage()
    {
        Destroy(gameObject);
    }
}
