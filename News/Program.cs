using Blazored.LocalStorage;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using News.Helpers;
using News.Services;

namespace News
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			// Modify HTML <head> in components: https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-7/
			//builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddOptions();
			builder.Services.AddAuthorizationCore(config =>
			{
				config.AddPolicy(Policies.IsAdministrator, Policies.IsAdministratorPolicy());
				config.AddPolicy(Policies.IsModerator, Policies.IsModeratorPolicy());
				config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
			});
			builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
			builder.Services.AddScoped<IAuthService, AuthService>();

			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddMudServices(config =>
			{
				config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
				config.SnackbarConfiguration.PreventDuplicates = false;
				config.SnackbarConfiguration.NewestOnTop = false;
				config.SnackbarConfiguration.ShowCloseIcon = true;
				config.SnackbarConfiguration.VisibleStateDuration = 5000;
				config.SnackbarConfiguration.HideTransitionDuration = 250;
				config.SnackbarConfiguration.ShowTransitionDuration = 250;
				config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
			});

			builder.Services.AddSingleton(services =>
			{
				var configuration = services.GetRequiredService<IConfiguration>();
				var backendUrl = $"https://{configuration["Settings:BackEndUrl"]}";

				// Create a channel with a GrpcWebHandler that is addressed to the backend server.
				// GrpcWebText is used because server streaming requires it. If server streaming is not used in your app
				// then GrpcWeb is recommended because it produces smaller messages.
				var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
				return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions
				{
					HttpHandler = httpHandler
					//MaxReceiveMessageSize = 1 * 1024 * 1024, // 1MB
					//MaxSendMessageSize = 1 * 1024 * 1024, // 1MB
					//MaxRetryAttempts = 3 // ?? #TODO
				});
			});

			builder.Services.AddScoped<ClipboardService>();

			builder.Services.AddHttpClient("IP", (options) => {
				options.Timeout = TimeSpan.FromSeconds(3);
				options.BaseAddress = new Uri("https://jsonip.com");
			});
			builder.Services.AddScoped<IApiClientService, ApiClientService>();

			await builder.Build().RunAsync();
		}
	}
}
