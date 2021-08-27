using News.Models;

namespace News.Services
{
	public interface IApiClientService
	{
		Task<IPAddress2> GetUserIPAsync();
	}
}
