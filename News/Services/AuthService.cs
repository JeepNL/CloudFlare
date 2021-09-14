using Blazored.LocalStorage;
using Grpc.Core;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace News.Services
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly ILocalStorageService _localStorage;

		public AuthService(HttpClient httpClient,
						   AuthenticationStateProvider authenticationStateProvider,
						   ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
			_localStorage = localStorage;
		}

		public async Task SetToken(string Token)
		{
			await _localStorage.SetItemAsync("authToken", Token);
			((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(Token);
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);
		}

		public async Task Logout()
		{
			await _localStorage.RemoveItemAsync("authToken");
			((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
			_httpClient.DefaultRequestHeaders.Authorization = null;
		}

		public async Task<Metadata> AddMetaDataHeader()
		{
			Metadata headers = new();
			string token = await _localStorage.GetItemAsync<string>("authToken");
			if (token != null)
			{
				headers.Add("Authorization", $"Bearer {token}");
			}
			return headers;
		}
	}
}
