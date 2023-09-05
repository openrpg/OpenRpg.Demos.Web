using OpenRpg.Combat.Processors;
using OpenRpg.Core.Stats.Populators;
using OpenRpg.Core.Utils;
using OpenRpg.Demos.Infrastructure.DI;
using OpenRpg.Genres.Fantasy.Combat;
using OpenRpg.Genres.Fantasy.Requirements;
using OpenRpg.Genres.Fantasy.Stats;
using OpenRpg.Genres.Requirements;

namespace OpenRpg.Demos.Web.Modules
{
    public class OpenRpgModule : IModule
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<IStatPopulator, FantasyStatsPopulator>();
            services.AddSingleton<IRandomizer>(x => new DefaultRandomizer(new Random()));
            services.AddSingleton<IAttackGenerator, BasicAttackGenerator>();
            services.AddSingleton<IAttackProcessor, DefaultAttackProcessor>();
            services.AddSingleton<ICharacterRequirementChecker, DefaultFantasyCharacterRequirementChecker>();
        }
    }
}