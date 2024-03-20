using System.Xml.Serialization;

namespace NewsRead.Services.Models;

[XmlRoot(ElementName = "rss")]
public class Rss
{
	[XmlElement(ElementName = "channel")]
	public Channel? Channel { get; set; }
}

public class Channel
{
	[XmlElement(ElementName = "title")]
	public string? Title { get; set; }

	[XmlElement(ElementName = "description")]
	public string? Description { get; set; }

	[XmlElement(ElementName = "link")]
	public string? Link { get; set; }

	[XmlElement(ElementName = "image")]
	public Image? Image { get; set; }

	[XmlElement(ElementName = "generator")]
	public string? Generator { get; set; }

	[XmlElement(ElementName = "lastBuildDate")]
	public string? LastBuildDate { get; set; }

	[XmlElement(ElementName = "atom:link")]
	public AtomLink? AtomLink { get; set; }

	[XmlElement(ElementName = "copyright")]
	public string? Copyright { get; set; }

	[XmlElement(ElementName = "language")]
	public string? Language { get; set; }

	[XmlElement(ElementName = "ttl")]
	public int Ttl { get; set; }

	[XmlElement(ElementName = "item")]
	public List<Item>? Items { get; set; }
}

public class Image
{
	[XmlElement(ElementName = "url")]
	public string? Url { get; set; }

	[XmlElement(ElementName = "title")]
	public string? Title { get; set; }

	[XmlElement(ElementName = "link")]
	public string? Link { get; set; }
}

public class AtomLink
{
	[XmlAttribute(AttributeName = "href")]
	public string? Href { get; set; }

	[XmlAttribute(AttributeName = "rel")]
	public string? Rel { get; set; }

	[XmlAttribute(AttributeName = "type")]
	public string? Type { get; set; }
}

public class Item
{
	[XmlElement(ElementName = "title")]
	public string? Title { get; set; }

	[XmlElement(ElementName = "description")]
	public string? Description { get; set; }

	[XmlElement(ElementName = "link")]
	public string? Link { get; set; }

	[XmlElement(ElementName = "guid")]
	public Guid? Guid { get; set; }

	[XmlElement(ElementName = "pubDate")]
	public string? PubDate { get; set; }

	[XmlElement(ElementName = "media:thumbnail")]
	public Thumbnail? Thumbnail { get; set; }
}

public class Guid
{
	[XmlAttribute(AttributeName = "isPermaLink")]
	public bool IsPermaLink { get; set; }

	[XmlText]
	public string? Value { get; set; }
}

public class Thumbnail
{
	[XmlAttribute(AttributeName = "width")]
	public int Width { get; set; }

	[XmlAttribute(AttributeName = "height")]
	public int Height { get; set; }

	[XmlAttribute(AttributeName = "url")]
	public string? Url { get; set; }
}
