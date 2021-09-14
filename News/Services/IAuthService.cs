using Grpc.Core;
using System.Threading.Tasks;

namespace News.Services
{
	public interface IAuthService
	{
		Task Logout();
		Task SetToken(string Token);
		Task<Metadata> AddMetaDataHeader();
	}
}
