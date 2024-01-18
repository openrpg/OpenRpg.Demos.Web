using OpenRpg.Combat.Processors.Attacks;
using OpenRpg.Combat.Processors.Attacks.Entity;
using OpenRpg.Core.Stats.Entity;
using OpenRpg.Core.Utils;
using OpenRpg.Demos.Infrastructure.DI;
using OpenRpg.Demos.Infrastructure.Scheduling;
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
            services.AddSingleton<IUpdateScheduler, DefaultUpdateScheduler>();
         
            services.AddSingleton<IEntityStatPopulator>(new FantasyStatsPopulator(new IEntityPartialStatPopulator[] {new DamageStatPopulator(), new DefenseStatPopulator()}));
            services.AddSingleton<IRandomizer>(x => new DefaultRandomizer(new Random()));
            services.AddSingleton<IEntityAttackGenerator, BasicAttackGenerator>();
            services.AddSingleton<IAttackProcessor<IEntityStatsVariables>, DefaultAttackProcessor>();
            services.AddSingleton<ICharacterRequirementChecker, DefaultFantasyCharacterRequirementChecker>();
        }
    }
}