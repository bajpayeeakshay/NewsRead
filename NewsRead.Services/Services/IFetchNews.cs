using NewsRead.Services.Common;
using NewsRead.Services.Models;

namespace NewsRead.Services.Services;

public interface IFetchNews
{
	Task<RequestResult<RssResponseModel>> FetchNewsForPage(int page, int? pageSize = 3);
}
