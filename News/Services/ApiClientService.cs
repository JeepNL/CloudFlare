using News.Models;
using System.Net.Http.Json;

namespace News.Services
{
	public class ApiClientService : IApiClientService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ApiClientService(IHttpClientFactory httpClientfactory)
		{
			_httpClientFactory = httpClientfactory;
		}

		public async Task<IPAddress2> GetUserIPAsync()
		{
			IPAddress2 returnIP = new() {
				IP = string.Empty,
				GeoIP = string.Empty,
				APIHelp = string.Empty
			};

			var client = _httpClientFactory.CreateClient("IP");
			try
			{
				returnIP = await client.GetFromJsonAsync<IPAddress2>("/");
			}
			catch (Exception ex)
			{
				returnIP.IP = $"Error: {ex}";
			}

			return returnIP;
		}
	}
}
