using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedImage : MonoBehaviour
{
    [SerializeField] private LargeImage largeImagePrefab;
    [SerializeField] private Image image;
    [SerializeField] private string caption;

    private Canvas canvas;

    public void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();

        DoubleClickButton button = gameObject.GetComponent<DoubleClickButton>();
        button.OnDoubleClick += ShowLargeImage;
    }

    public void Setup(Sprite displaySprite, string imageCaption)
    {
        image.sprite = displaySprite;
        caption = imageCaption;
    }

    private void ShowLargeImage()
    {
        LargeImage newImage = Instantiate(largeImagePrefab, canvas.transform, false);
        newImage.Setup(image.sprite, caption);
    }
}
