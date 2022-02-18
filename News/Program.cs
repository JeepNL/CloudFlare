using Blazored.LocalStorage;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using News;
using News.Helpers;
using News.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Modify HTML <head> in components: https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-7/
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.RootComponents.Add<App>("#app");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

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
	config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
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

builder.Services.AddSingleton<ClipboardService>();

// Singleton is perfect for a client-side Blazor app, but if you are working with server-side Blazor,
// you will want to register as a Scoped service so each different user receives his/her own instance
// of the service for the duration of their session.
// https://wellsb.com/csharp/aspnet/blazor-singleton-pass-data-between-pages
// AND => https://code-maze.com/dependency-injection-lifetimes-aspnet-core/

builder.Services.AddSingleton<UserCookieService>();
builder.Services.AddSingleton<ICookieService, CookieService>();

await builder.Build().RunAsync();
