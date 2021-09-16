**Static Blazor WASM Website on CloudFlare Pages**

Live Site: https://blazorbits.openwiki.com/

[Niels Swimberghe](https://twitter.com/RealSwimburger) wrote a great [blog post](https://swimburger.net/blog/dotnet/how-to-deploy-blazor-webassembly-to-cloudflare-pages) on how to deploy your Blazor WebAssembly Static Website to [CloudFlare Pages](https://pages.cloudflare.com/).

To use the latest .NET 6 RC1 SDK on Cloudflare Pages you'll need to modify the build command: 👇

`wget https://download.visualstudio.microsoft.com/download/pr/4880c5a4-9c22-47a7-b298-651f1294a385/795f7828d8684059705e625b33027f89/dotnet-sdk-6.0.100-rc.1.21458.32-linux-x64.tar.gz;tar zxf dotnet-sdk-6.0.100-rc.1.21458.32-linux-x64.tar.gz;./dotnet workload install wasm-tools;./dotnet --info;./dotnet publish -c Release -o output;`

For **wasm-tools** to work you'll need to set the environment variable **PYTHON_VERSION** to **3.7** in Cloudflare Pages settings.

This live prototype receives its data from remote .NET 6 gRPC services running on a co-located Ubuntu VPS.

Everything .NET! 😉

![Static Blazor WASM Website on CloudFlare Pages](Screenshot.jpg)
