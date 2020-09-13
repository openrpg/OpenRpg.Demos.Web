using Microsoft.Extensions.DependencyInjection;
using OpenRpg.Demos.Infrastructure.Builders;
using OpenRpg.Demos.Infrastructure.Data;
using OpenRpg.Demos.Infrastructure.DI;
using OpenRpg.Demos.Infrastructure.Locale;

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