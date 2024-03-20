using System.Xml.Serialization;

namespace NewsRead.Services.Models;

[XmlRoot(ElementName = "rss")]
public class RssResponseModel
{
	[XmlElement(ElementName = "channel")]
	public ChannelResponseModel? Channel { get; set; }
}

public class ChannelResponseModel
{
	[XmlElement(ElementName = "title")]
	public string? Title { get; set; }

	[XmlElement(ElementName = "description")]
	public string? Description { get; set; }

	[XmlElement(ElementName = "link")]
	public string? Link { get; set; }

	[XmlElement(ElementName = "image")]
	public ImageResponseModel? Image { get; set; }

	[XmlElement(ElementName = "generator")]
	public string? Generator { get; set; }

	[XmlElement(ElementName = "lastBuildDate")]
	public string? LastBuildDate { get; set; }

	[XmlElement(ElementName = "atom:link")]
	public AtomLinkResponseModel? AtomLink { get; set; }

	[XmlElement(ElementName = "copyright")]
	public string? Copyright { get; set; }

	[XmlElement(ElementName = "language")]
	public string? Language { get; set; }

	[XmlElement(ElementName = "ttl")]
	public int Ttl { get; set; }

	[XmlElement(ElementName = "item")]
	public List<ItemResponseModel>? Items { get; set; }
}

public class ImageResponseModel
{
	[XmlElement(ElementName = "url")]
	public string? Url { get; set; }

	[XmlElement(ElementName = "title")]
	public string? Title { get; set; }

	[XmlElement(ElementName = "link")]
	public string? Link { get; set; }
}

public class AtomLinkResponseModel
{
	[XmlAttribute(AttributeName = "href")]
	public string? Href { get; set; }

	[XmlAttribute(AttributeName = "rel")]
	public string? Rel { get; set; }

	[XmlAttribute(AttributeName = "type")]
	public string? Type { get; set; }
}

public class ItemResponseModel
{
	[XmlElement(ElementName = "title")]
	public string? Title { get; set; }

	[XmlElement(ElementName = "description")]
	public string? Description { get; set; }

	[XmlElement(ElementName = "link")]
	public string? Link { get; set; }

	[XmlElement(ElementName = "guid")]
	public GuidResponseModel? Guid { get; set; }

	[XmlElement(ElementName = "pubDate")]
	public string? PubDate { get; set; }

	[XmlElement(ElementName = "media:thumbnail")]
	public ThumbnailResponseModel? Thumbnail { get; set; }
}

public class GuidResponseModel
{
	[XmlAttribute(AttributeName = "isPermaLink")]
	public bool IsPermaLink { get; set; }

	[XmlText]
	public string? Value { get; set; }
}

public class ThumbnailResponseModel
{
	[XmlAttribute(AttributeName = "width")]
	public int Width { get; set; }

	[XmlAttribute(AttributeName = "height")]
	public int Height { get; set; }

	[XmlAttribute(AttributeName = "url")]
	public string? Url { get; set; }
}
