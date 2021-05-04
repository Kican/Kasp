using Kasp.Panel.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel
{
    public static class KaspPanelExtensions
    {
        public static void AddKaspPanel(this IServiceCollection services)
        {
            services.AddScoped<ISidebarMenuService, SidebarMenuService>();
        }
    }
}