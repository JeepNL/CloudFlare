**Static Blazor WASM Website on CloudFlare Pages**

Live Site: https://blazorbits.openwiki.com/

[Niels Swimberghe](https://twitter.com/RealSwimburger) wrote a great [blog post](https://swimburger.net/blog/dotnet/how-to-deploy-blazor-webassembly-to-cloudflare-pages) on how to deploy your Blazor WebAssembly Static Website to [CloudFlare Pages](https://pages.cloudflare.com/).

To use the latest .NET 6.0.100 SDK (November 8th, 2021) on Cloudflare Pages you'll need to modify the build command: 👇

`wget https://download.visualstudio.microsoft.com/download/pr/17b6759f-1af0-41bc-ab12-209ba0377779/e8d02195dbf1434b940e0f05ae086453/dotnet-sdk-6.0.100-linux-x64.tar.gz;tar zxf dotnet-sdk-6.0.100-linux-x64.tar.gz;./dotnet workload install wasm-tools;./dotnet --info;./dotnet publish -c Release -o output --self-contained;`

For **wasm-tools** to work you'll need to set the environment variable **PYTHON_VERSION** to **3.7** in Cloudflare Pages settings.

This live prototype receives its data from remote .NET 6 gRPC services running on a co-located Ubuntu VPS.

Everything .NET! 😉

![Static Blazor WASM Website on CloudFlare Pages](Screenshot.jpg)


