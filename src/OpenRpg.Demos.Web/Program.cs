using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OpenRpg.Demos.Web.Extensions;
using OpenRpg.Demos.Web.Modules;

namespace OpenRpg.Demos.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddModule<OpenRpgModule>();
            builder.Services.AddModule<OpenRpgDataModule>();

            await builder.Build().RunAsync();
        }
    }
}
