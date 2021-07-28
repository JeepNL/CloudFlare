using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.Configuration;

namespace News
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			//builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton(services =>
			{
				var configuration = services.GetRequiredService<IConfiguration>();
				var backendUrl = $"https://{configuration["Settings:BackEndUrl"]}";

				// Create a channel with a GrpcWebHandler that is addressed to the backend server.
				// GrpcWebText is used because server streaming requires it. If server streaming is not used in your app
				// then GrpcWeb is recommended because it produces smaller messages.
				var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
				return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions {
					HttpHandler = httpHandler
					//MaxReceiveMessageSize = 1 * 1024 * 1024, // 1MB
					//MaxSendMessageSize = 1 * 1024 * 1024, // 1MB
					//MaxRetryAttempts = 3 // ?? #TODO
				});
			});

			builder.Services.AddMudServices();

			await builder.Build().RunAsync();
		}
	}
}
