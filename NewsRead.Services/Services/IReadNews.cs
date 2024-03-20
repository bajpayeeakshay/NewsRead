using NewsRead.Services.Models;

namespace NewsRead.Services.Services;

public interface IReadNews
{
	Task<Rss?> FetchAllLatestNews();
}
