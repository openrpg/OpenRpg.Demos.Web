using System;
using Microsoft.Extensions.DependencyInjection;
using OpenRpg.Combat.Processors;
using OpenRpg.Core.Stats;
using OpenRpg.Core.Utils;
using OpenRpg.Demos.Infrastructure.DI;
using OpenRpg.Genres.Fantasy.Combat;
using OpenRpg.Genres.Fantasy.Defaults;
using OpenRpg.Genres.Fantasy.Requirements;
using OpenRpg.Genres.Fantasy.Stats;
using OpenRpg.Genres.Requirements;

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
            services.AddSingleton<IAttackProcessor, DefaultAttackProcessor>();
            services.AddSingleton<ICharacterRequirementChecker, DefaultFantasyCharacterRequirementChecker>();
        }
    }
}