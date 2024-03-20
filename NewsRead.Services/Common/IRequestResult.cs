namespace NewsRead.Services.Common;

public interface IRequestResult
{
	RequestError Error { get; }

	bool IsSuccess { get; }
}

