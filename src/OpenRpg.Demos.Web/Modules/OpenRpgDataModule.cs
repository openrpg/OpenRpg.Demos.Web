using Microsoft.Extensions.DependencyInjection;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Races;
using OpenRpg.Data;
using OpenRpg.Data.InMemory;
using OpenRpg.Demos.Infrastructure.Builders;
using OpenRpg.Demos.Infrastructure.Data;
using OpenRpg.Demos.Infrastructure.DI;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Locale;
using OpenRpg.Items.Templates;
using OpenRpg.Localization.Data.DataSources;
using OpenRpg.Localization.Data.Repositories;

namespace OpenRpg.Demos.Web.Modules
{
    public class OpenRpgDataModule : IModule
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<IDataSource>(x => GenerateDataSource());
            services.AddSingleton<ILocaleDataSource>(x => GenerateLocaleDataSource());
            services.AddSingleton<IRepository, DefaultRepository>();
            services.AddSingleton<ILocaleRepository>(x => new LocaleRepository(x.GetService<ILocaleDataSource>(), "en-gb"));
            services.AddSingleton<CharacterBuilder>();
        }

        public InMemoryDataSource GenerateDataSource()
        {
            var data = new Dictionary<Type, Dictionary<object, object>>();
            data.Add(typeof(IRaceTemplate), new RaceTemplateDataGenerator().GenerateDictionary());
            data.Add(typeof(IClassTemplate), new ClassTemplateDataGenerator().GenerateDictionary());
            data.Add(typeof(IItemTemplate), new ItemTemplateDataGenerator().GenerateDictionary());
            return new InMemoryDataSource(data);
        }

        public InMemoryLocaleDataSource GenerateLocaleDataSource()
        {
            var data = new LocaleDataGenerator().GenerateData();
            return new InMemoryLocaleDataSource(data);
        }
    }
}