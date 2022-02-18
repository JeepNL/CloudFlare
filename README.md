**Static Blazor WASM Website on CloudFlare Pages**

Live Site: https://blazorbits.openwiki.com/

[Niels Swimberghe](https://twitter.com/RealSwimburger) wrote a great [blog post](https://swimburger.net/blog/dotnet/how-to-deploy-blazor-webassembly-to-cloudflare-pages) on how to deploy your Blazor WebAssembly Static Website to [CloudFlare Pages](https://pages.cloudflare.com/).

To use the latest .NET 7.0.0 Preview 1 SDK (February 17, 2022) on Cloudflare Pages you'll need to modify the build command: 👇

`wget https://download.visualstudio.microsoft.com/download/pr/1af9d3c3-a20e-400c-abe5-3d80dec7b63b/803f8dc5cf21fb28245aba71a7fdbc05/dotnet-sdk-7.0.100-preview.1.22110.4-linux-x64.tar.gz;tar zxf dotnet-sdk-7.0.100-preview.1.22110.4-linux-x64.tar.gz;./dotnet workload install wasm-tools;./dotnet --info;./dotnet publish -c Release -o output --self-contained;`

For **wasm-tools** to work you'll need to set the environment variable **PYTHON_VERSION** to **3.7** in Cloudflare Pages settings.

This live prototype receives its data from remote .NET 7 Preview gRPC services running on a co-located Ubuntu VPS.

Everything .NET! 😉

![Static Blazor WASM Website on CloudFlare Pages](Screenshot.jpg)


