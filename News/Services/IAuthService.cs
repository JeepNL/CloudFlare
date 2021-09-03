using Grpc.Core;
using News.Models;

namespace News.Services
{
	public interface IAuthService
	{
		Task Logout();
		Task SetToken(string Token);
		Task<Metadata> AddMetaDataHeader();
	}
}
