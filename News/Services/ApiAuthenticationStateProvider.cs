using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace News.Services
{
	public class ApiAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly HttpClient _httpClient;
		private readonly ILocalStorageService _localStorage;

		public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_localStorage = localStorage;
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			ClaimsIdentity claimsIdentity;
			string savedToken = await _localStorage.GetItemAsync<string>("authToken");

			if (string.IsNullOrEmpty(savedToken))
				return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
			else
			{
				claimsIdentity = new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt");
				long expClaim = Convert.ToInt64(claimsIdentity.FindFirst(c => c.Type == "exp")?.Value);
				DateTimeOffset dtOffsetClaimExp = DateTimeOffset.FromUnixTimeSeconds(expClaim).ToLocalTime();
				DateTimeOffset dtOffsetNow = DateTimeOffset.Now;
				if (dtOffsetNow > dtOffsetClaimExp)
				{
					await _localStorage.RemoveItemAsync("authToken");

					// from MarkUserAsLoggedOut below
					// not "MarkUserAsLoggedOut()" because of "anonymousUser" --> return new AuthenticationState(anonymousUser);
					ClaimsPrincipal anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
					Task<AuthenticationState> authState = Task.FromResult(new AuthenticationState(anonymousUser));
					NotifyAuthenticationStateChanged(authState);

					// from AuthService.cs - Logout
					_httpClient.DefaultRequestHeaders.Authorization = null;
					return new AuthenticationState(anonymousUser);
				}
			}

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
			return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
		}

		public void MarkUserAsAuthenticated(string token)
		{
			var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
			var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
			NotifyAuthenticationStateChanged(authState);
		}

		public void MarkUserAsLoggedOut()
		{
			var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
			var authState = Task.FromResult(new AuthenticationState(anonymousUser));
			NotifyAuthenticationStateChanged(authState);
		}

		private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var claims = new List<Claim>();
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

			keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

			if (roles != null)
			{
				if (roles.ToString().Trim().StartsWith("["))
				{
					var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

					foreach (var parsedRole in parsedRoles)
					{
						claims.Add(new Claim(ClaimTypes.Role, parsedRole));
					}
				}
				else
				{
					claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
				}

				keyValuePairs.Remove(ClaimTypes.Role);
			}

			claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

			return claims;
		}

		private static byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2: base64 += "=="; break;
				case 3: base64 += "="; break;
			}
			return Convert.FromBase64String(base64);
		}
	}
}
