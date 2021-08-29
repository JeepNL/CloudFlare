using Blazored.LocalStorage;
using Grpc.Core;
using Microsoft.AspNetCore.Components.Authorization;
using News.Helpers;
using News.Models;
using System.Net.Http.Headers;
using System.Security.Claims;

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

		// Check if authToken isn't expired (in App.razor)
		// #TODO Do this in ApiAuthenticationStateProvider.cs instead of here.
		public async Task<UserModel> ValidateAuth()
		{
			UserModel ValidateUser = new();
			IEnumerable<Claim> userClaims = Enumerable.Empty<Claim>();
			AuthenticationState authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
			ClaimsPrincipal user = authState.User;

			if (!user.Identity.IsAuthenticated)
				return ValidateUser;

			ValidateUser.Email = user.Identity.Name;
			userClaims = user.Claims;
			//long expClaim = Convert.ToInt64(userClaims.FirstOrDefault(e => e.Type == "exp")?.Value);
			long expClaimUnix = Convert.ToInt64(user.FindFirst(c => c.Type == "exp")?.Value);
			DateTimeOffset dtClaimExp = DateTimeOffset.FromUnixTimeSeconds(expClaimUnix).ToLocalTime();
			DateTimeOffset dtClaimNow = DateTimeOffset.Now;

			if (dtClaimNow < dtClaimExp)
			{
				// #TODO Refresh Token, see App.Razor
				ValidateUser.IsAuthenticated = true;
			}

			return ValidateUser;
		}
	}
}
