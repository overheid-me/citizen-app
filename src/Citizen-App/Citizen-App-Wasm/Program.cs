using Citizen_App_Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Citizen_App_Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Configuration.AddJsonFile("wwwroot/appsettings.json");
            Initializer.Initialize(builder.Services, builder.Configuration);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            Initializer.Initialize(builder.Services, builder.Configuration);
            await builder.Build().RunAsync();
        }
    }
}
