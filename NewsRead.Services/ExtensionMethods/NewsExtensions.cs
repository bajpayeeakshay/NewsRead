using NewsRead.Services.Models;
using Guid = NewsRead.Services.Models.Guid;

namespace NewsRead.Services.ExtensionMethods;

public static class NewsExtensions
{
	public static RssResponseModel ToRssResponseModel(this Rss rss, List<Item>? items)
	{
		return new RssResponseModel
		{
			Channel = rss.Channel?.ToChannelResponseModel(items)
		};
	}

	public static ChannelResponseModel ToChannelResponseModel(this Channel channel, List<Item>? items)
	{
		return new ChannelResponseModel
		{
			Title = channel.Title,
			Description = channel.Description,
			Link = channel.Link,
			Image = channel.Image?.ToImageResponseModel(),
			Generator = channel.Generator,
			LastBuildDate = channel.LastBuildDate,
			AtomLink = channel.AtomLink?.ToAtomLinkResponseModel(),
			Copyright = channel.Copyright,
			Language = channel.Language,
			Ttl = channel.Ttl,
			Items = items?.Select(x => x.ToItemResponseModel()).ToList(),
		};
	}

	public static ImageResponseModel ToImageResponseModel(this Image image)
	{
		return new ImageResponseModel
		{
			Title = image.Title,
			Url = image.Url,
			Link = image.Link,
		};
	}

	public static AtomLinkResponseModel ToAtomLinkResponseModel(this AtomLink atomLink)
	{
		return new AtomLinkResponseModel
		{
			Href = atomLink.Href,
			Rel = atomLink.Rel,
			Type = atomLink.Type,
		};
	}

	public static ItemResponseModel ToItemResponseModel(this Item item)
	{
		return new ItemResponseModel
		{
			Title = item.Title,
			Description = item.Description,
			Link = item.Link,
			Guid = item.Guid?.ToGuidResponseModel(),
			PubDate = item.PubDate,
			Thumbnail = item.Thumbnail?.ToThumbNailResponseModel()
		};
	}

	public static GuidResponseModel ToGuidResponseModel(this Guid guid)
	{
		return new GuidResponseModel
		{
			IsPermaLink = guid.IsPermaLink,
			Value = guid.Value,
		};
	}

	public static ThumbnailResponseModel ToThumbNailResponseModel(this Thumbnail thumbnail)
	{
		return new ThumbnailResponseModel
		{
			Width = thumbnail.Width,
			Height = thumbnail.Height,
			Url = thumbnail.Url,
		};
	}
}
