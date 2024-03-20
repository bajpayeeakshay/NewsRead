using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsRead.Services.Models;
using NewsRead.Services.Services;
using ILogger = Serilog.ILogger;

namespace NewsRead.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
	private readonly ILogger _logger;
	private readonly IFetchNews _fetchNews;

	public NewsController(IFetchNews fetchNews, ILogger logger)
	{
		_logger = logger.ForContext<NewsController>();
		_fetchNews = fetchNews;
	}

	[HttpPost(nameof(FetchNews))]
	public async Task<IActionResult> FetchNews([FromBody] FetchNewsRequestModel request)
	{
		_logger.Information("Endpoint to fetch news is being executed");
		if (request.PageSize < 1)
		{
			request.PageSize = 3;
		}
		var rssFeed = await _fetchNews.FetchNewsForPage(request.PageNumber, request.PageSize);

		if (rssFeed.IsSuccess)
		{
			_logger.Information("Endpoint to fetch news returned news successfully");
			return Ok(rssFeed.GetResult());
		}
		else
		{
			_logger.Warning($"Error occurred while fetching news: {rssFeed.Error}");
			return BadRequest(rssFeed.Error);
		}
	}
}
