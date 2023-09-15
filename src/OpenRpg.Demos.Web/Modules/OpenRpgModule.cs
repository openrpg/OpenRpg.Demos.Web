using OpenRpg.Combat.Processors.Attacks;
using OpenRpg.Core.Stats.Entity;
using OpenRpg.Core.Utils;
using OpenRpg.Demos.Infrastructure.DI;
using OpenRpg.Genres.Fantasy.Combat;
using OpenRpg.Genres.Fantasy.Requirements;
using OpenRpg.Genres.Fantasy.Stats;
using OpenRpg.Genres.Populators.Entity.Stats;
using OpenRpg.Genres.Requirements;

namespace OpenRpg.Demos.Web.Modules
{
    public class OpenRpgModule : IModule
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<IEntityStatPopulator, FantasyStatsPopulator>();
            services.AddSingleton<IRandomizer>(x => new DefaultRandomizer(new Random()));
            services.AddSingleton<IAttackGenerator, BasicAttackGenerator>();
            services.AddSingleton<IAttackProcessor<IEntityStatsVariables>, DefaultAttackProcessor>();
            services.AddSingleton<ICharacterRequirementChecker, DefaultFantasyCharacterRequirementChecker>();
        }
    }
}