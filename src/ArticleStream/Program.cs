using ArticleStream;
using ArticleStream.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
ConfigureRootComponents(builder);
ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);
await builder.Build().RunAsync();

void ConfigureRootComponents(WebAssemblyHostBuilder builder)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
    services.AddScoped<DisplayArticleService>();
    services.AddScoped<IErrorLogger, ConsoleErrorLogger>();
}
