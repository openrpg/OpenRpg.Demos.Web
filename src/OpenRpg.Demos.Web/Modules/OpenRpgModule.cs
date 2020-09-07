using System;
using Microsoft.Extensions.DependencyInjection;
using OpenRpg.Combat.Processors;
using OpenRpg.Core.Defaults;
using OpenRpg.Core.Races;
using OpenRpg.Core.Stats;
using OpenRpg.Core.Utils;
using OpenRpg.Data.Defaults;
using OpenRpg.Data.Repositories;
using OpenRpg.Demos.Web.Infrastructure.DI;
using OpenRpg.Demos.Web.Infrastructure.OpenRpg.Data;
using OpenRpg.Demos.Web.Infrastructure.OpenRpg.Random;
using OpenRpg.Genres.Fantasy.Combat;
using OpenRpg.Genres.Fantasy.Defaults;
using OpenRpg.Genres.Fantasy.Stats;

namespace OpenRpg.Demos.Web.Modules
{
    public class OpenRpgModule : IModule
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<IAttributeStatPopulator, DefaultAttributeStatPopulator>();
            services.AddSingleton<IVitalStatsPopulator, DefaultVitalStatsPopulator>();
            services.AddSingleton<IDamageStatPopulator, DefaultDamageStatPopulator>();
            services.AddSingleton<IDefenseStatPopulator, DefaultDefenseStatPopulator>();
            services.AddSingleton<IStatsComputer, DefaultStatsComputer>();
            services.AddSingleton<IRandomizer>(x => new DefaultRandomizer(new Random()));
            services.AddSingleton<IAttackGenerator, BasicAttackGenerator>();
            services.AddSingleton<IAttackGenerator, BasicAttackGenerator>();
            services.AddSingleton<IAttackProcessor, DefaultAttackProcessor>();
        }
    }
}