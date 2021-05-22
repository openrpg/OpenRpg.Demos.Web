using System.Collections.Generic;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Requirements;
using OpenRpg.Data.Defaults;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;

namespace OpenRpg.Demos.Infrastructure.Data
{
    public class ClassRepository : InMemoryDataRepository<IClassTemplate>
    {
        public ClassRepository()
        {
            Data = new List<IClassTemplate>
            {
                GenerateFighterClass(),
                GenerateMageClass()
            };
        }

        private IClassTemplate GenerateFighterClass()
        {
            var effects = new[]
            {
                new Effect {Potency = 2, EffectType = EffectTypes.StrengthBonusAmount},
                new Effect {Potency = 2, EffectType = EffectTypes.ConstitutionBonusAmount},
                new Effect {Potency = 5, EffectType = EffectTypes.PureDamageAmount},
                new Effect {Potency = 5, EffectType = EffectTypes.PureDefenseAmount},
                new Effect {Potency = 30, EffectType = EffectTypes.HealthBonusAmount}
            };

            var classTemplate = new DefaultClassTemplate
            {
                Id = ClassTypeLookups.Fighter,
                NameLocaleId = "Fighter",
                DescriptionLocaleId = "Super tough, hits things",
                Effects = effects
            };
            classTemplate.Variables.AssetCode("class-fighter");
            return classTemplate;
        }

        private IClassTemplate GenerateMageClass()
        {
            var effects = new[]
            {
                new Effect {Potency = 4, EffectType = EffectTypes.IntelligenceBonusAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.DarkDamageAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.DarkDefenseAmount},
                new Effect {Potency = 30, EffectType = EffectTypes.MagicBonusAmount}
            };

            var classTemplate = new DefaultClassTemplate
            {
                Id = ClassTypeLookups.Mage,
                NameLocaleId = "Mage",
                DescriptionLocaleId = "Powerful magic users",
                Effects = effects
            };
            classTemplate.Variables.AssetCode("class-mage");
            return classTemplate;
        }
    }
}