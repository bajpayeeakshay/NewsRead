using NewsRead.Services.Models;
using Serilog;
using System.Xml.Serialization;

namespace NewsRead.Services.Services;

public class ReadNews : IReadNews
{
	private readonly HttpClient _httpClient;
	private readonly ILogger _logger;

	public ReadNews(HttpClient httpClient, ILogger logger)
	{
		_httpClient = httpClient;
		_logger = logger;
	}

	public async Task<Rss?> FetchAllLatestNews()
	{
		try
		{
			var response = await _httpClient.GetAsync(_httpClient.BaseAddress);

			if (response.IsSuccessStatusCode)
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Rss));
				var stream = await response.Content.ReadAsStreamAsync();
				var result = serializer.Deserialize(stream) as Rss;
				_logger.Information("Successfully retrieved news from API");
				return result;
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex, "Error occurred while fetching news from API");
		}

		return null;
	}
}
