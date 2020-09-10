using Microsoft.Extensions.DependencyInjection;
using OpenRpg.Demos.Web.Infrastructure.DI;
using OpenRpg.Demos.Web.Infrastructure.OpenRpg.Builders;
using OpenRpg.Demos.Web.Infrastructure.OpenRpg.Data;
using OpenRpg.Demos.Web.Infrastructure.OpenRpg.Locale;

namespace OpenRpg.Demos.Web.Modules
{
    public class OpenRpgDataModule : IModule
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<RaceRepository>();
            services.AddSingleton<ClassRepository>();
            services.AddSingleton<CharacterBuilder>();
            services.AddSingleton<DefaultLocaleRepository>();
        }
    }
}