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

		public async Task<UserModel> ValidateAuth()
		{
			IEnumerable<Claim> userClaims = Enumerable.Empty<Claim>();

			UserModel ValidateUser = new()
			{
				Email = "",
				IsAuthenticated = false
			};

			AuthenticationState authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
			ClaimsPrincipal user = authState.User;

			if (user.Identity.Name == null)
			{
				return ValidateUser;
			}
			ValidateUser.Email = user.Identity.Name;

			userClaims = user.Claims;
			int expClaim = Convert.ToInt32(userClaims.FirstOrDefault(e => e.Type == "exp").Value);
			DateTimeOffset dtClaimExp = DateTimeOffset.FromUnixTimeSeconds(expClaim).ToLocalTime();
			DateTimeOffset dtClaimNow = DateTimeOffset.Now;

			if (dtClaimNow < dtClaimExp)
				ValidateUser.IsAuthenticated = true;

			return ValidateUser;
		}
	}
}
