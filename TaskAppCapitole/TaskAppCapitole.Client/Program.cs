using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TaskAppCapitole.Client.Services;
namespace TaskAppCapitole.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddMudServices();
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7257/") });
			builder.Services.AddScoped<TaskItemService>();
			await builder.Build().RunAsync();
        }
    }
}