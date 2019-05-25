using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedDisplay : MonoBehaviour
{
    [SerializeField] private Transform scrollContent;
    [SerializeField] private FeedSource feedSource;
    [SerializeField] private FeedImage imagePrefab;
    [SerializeField] private InfoButton infoButtonPrefab;

    public void AddSpriteToFeed(Sprite sprite, string caption)
    {
        FeedImage newImage = Instantiate(imagePrefab, scrollContent, false);
        newImage.Setup(sprite, caption);
    }

    public void AddInfoButton()
    {
        Instantiate(infoButtonPrefab, scrollContent, false);
    }


}
