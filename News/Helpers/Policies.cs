using Microsoft.AspNetCore.Authorization;

namespace News.Helpers
{
	public static class Policies
	{
		public const string IsAdministrator = "IsAdministrator";
		public const string IsModerator = "IsModerator";
		public const string IsUser = "IsUser";

		public static AuthorizationPolicy IsAdministratorPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Administrator")
												   .Build();
		}
		public static AuthorizationPolicy IsModeratorPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Moderator")
												   .Build();
		}
		public static AuthorizationPolicy IsUserPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("User")
												   .Build();
		}
	}
}
