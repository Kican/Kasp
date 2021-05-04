using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Kasp.Panel;
using Kasp.Panel.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PanelSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.Services.AddAntDesign();
            builder.Services.AddKaspPanel();

            var app = builder.Build();

            var sidebarMenuService = app.Services.GetRequiredService<ISidebarMenuService>();

            sidebarMenuService.AddMenu(new MenuItemData("salam", "https://google.com"));

            await app.RunAsync();
        }
    }
}