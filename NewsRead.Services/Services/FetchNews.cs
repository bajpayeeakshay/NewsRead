using Microsoft.Extensions.Caching.Memory;
using NewsRead.Services.Common;
using NewsRead.Services.ExtensionMethods;
using NewsRead.Services.Models;
using Serilog;

namespace NewsRead.Services.Services;

public class FetchNews : IFetchNews
{
	private readonly IReadNews _readNews;
	private readonly IMemoryCache _memoryCache;
	private readonly ILogger _logger;

	public FetchNews(IReadNews readNews, IMemoryCache memoryCache, ILogger logger)
	{
		_readNews = readNews;
		_memoryCache = memoryCache;
		_logger = logger;
	}

	public async Task<RequestResult<RssResponseModel>> FetchNewsForPage(int page, int? pageSize = 3)
	{
		Rss? news = null;

		if (_memoryCache.TryGetValue<Rss>("StoredNews", out Rss? storedNews))
		{
			_logger.Information("News is being retrieved from Cache");
			news = storedNews;
		}
		else
		{
			_logger.Information("News is being retrieved from the endpoint");
			news = await _readNews.FetchAllLatestNews();
			if (news != null)
			{
				_logger.Information("News is being set in the cache");
				_memoryCache.Set<Rss>("StoredNews", news);
			}
		}

		if (news == null)
		{
			_logger.Warning("No News Found");
			return RequestResult.Fail<RssResponseModel>(new RequestError("No News Found"));
		}

		if (pageSize != null)
		{
			var items = news.Channel?.Items?
							.Skip(page * pageSize.Value)
							.Take(pageSize.Value)
							.ToList();

			var result = news.ToRssResponseModel(items);

			_logger.Information("News is processed successfully");
			return RequestResult.Success(result);
		}

		_logger.Warning("Invalid Page Size");
		return RequestResult.Fail<RssResponseModel>(new RequestError("Invalid Page Size"));
	}
}
