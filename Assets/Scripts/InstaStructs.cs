using System.Collections;
using UnityEngine;

public struct InstaUserJSON
{
    public InstaData data;
}

public struct InstaTagJSON
{
    public InstaGraph graphql;
}

public struct InstaData
{
    public InstaUser user;
}

public struct InstaGraph
{
    public InstaTag hashtag;
}

public struct InstaUser
{
    public InstaMediaCollection edge_owner_to_timeline_media;
}

public struct InstaTag
{
    public InstaMediaCollection edge_hashtag_to_media;
}

public struct InstaMediaCollection
{
    public InstaEdge[] edges;
}

public struct InstaEdge
{
    public InstaNode node;
}

public struct InstaNode
{
    public InstaMediaCollection edge_media_to_caption;
    public string display_url;
    public string text;
}

public class InstaStructs
{
    public const string SPIKEBALL_URL = "https://www.instagram.com/graphql/query/?query_id=17888483320059182&id=237364272&first=200&after=QVFEVmV3aWVjenVrOVBDOWhIVWU1OTZycWVVcTAtWGpWc0JXd1hfOVFmLXU4TWh2VVBMUDdfOHhaVVV5YlYzWkp1cnk5MWRXMzlBN082Y1dUYnQ2TzExVQ==";
    public const string ROUNDNET_URL = "https://www.instagram.com/explore/tags/roundnet/?__a=1";
}
