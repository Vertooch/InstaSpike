using System.Collections;
using System.Collections.Generic;
//using System.Net;
using FullSerializer;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum FeedSource
{
    Spikeball,
    Roundnet
}

public class InstagramScraper : MonoBehaviour
{
    [SerializeField] private FeedDisplay spikeballFeed;
    [SerializeField] private FeedDisplay roundnetFeed;

    public void Start()
    {
        RefreshSpriteLists();
    }

    public void RefreshSpriteLists()
    {
        StartCoroutine(CreateSpriteListForSource(FeedSource.Spikeball));
        StartCoroutine(CreateSpriteListForSource(FeedSource.Roundnet));
    }

    IEnumerator CreateSpriteListForSource(FeedSource source)
    {
        string sourceUrl = source == FeedSource.Spikeball ? InstaStructs.SPIKEBALL_URL : InstaStructs.ROUNDNET_URL;

        string json = "";
        // Using the static constructor
        var request = UnityWebRequest.Get(sourceUrl);

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        json = request.downloadHandler.text;

        InstaEdge[] edges;

        if (source == FeedSource.Spikeball)
        {
            InstaUserJSON userJSON = Deserialize<InstaUserJSON>(json);
            edges = userJSON.data.user.edge_owner_to_timeline_media.edges;
        }
        else
        {
            InstaTagJSON tagJSON = Deserialize<InstaTagJSON>(json);
            edges = tagJSON.graphql.hashtag.edge_hashtag_to_media.edges;
        }
        yield return  GetSpritesForFeed(source, edges);
    }

    private T Deserialize<T>(string json)
    {
        // Parse the json string to fsData
        fsData data = fsJsonParser.Parse(json);

        // Deserialize the data to the input type
        object deserialized = null;
        fsSerializer _serializer = new fsSerializer();
        _serializer.TryDeserialize(data, typeof(T), ref deserialized);

        return (T)deserialized;
    }

    IEnumerator GetSpritesForFeed(FeedSource source, InstaEdge[] edges)
    {
        foreach (InstaEdge edge in edges)
        {
            string displayUrl = edge.node.display_url;
            yield return CreateSpriteFromUrl(source, displayUrl, edge.node.edge_media_to_caption.edges[0].node.text);
        }

        if (source == FeedSource.Spikeball)
            spikeballFeed.AddInfoButton();
        else
            roundnetFeed.AddInfoButton();
    }


    IEnumerator CreateSpriteFromUrl(FeedSource source, string displayUrl, string caption)
    {
        Sprite displaySprite = null;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(displayUrl))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                displaySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
        }

        if (displayUrl != null)
        {
            if (source == FeedSource.Spikeball)
                spikeballFeed.AddSpriteToFeed(displaySprite, caption);
            else
                roundnetFeed.AddSpriteToFeed(displaySprite, caption);
        }
    }
}
