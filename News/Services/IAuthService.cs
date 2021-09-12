using Grpc.Core;

namespace News.Services
{
	public interface IAuthService
	{
		Task Logout();
		Task SetToken(string Token);
		Task<Metadata> AddMetaDataHeader();
	}
}
