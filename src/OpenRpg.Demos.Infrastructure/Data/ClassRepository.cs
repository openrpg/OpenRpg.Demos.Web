using System.Collections.Generic;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Requirements;
using OpenRpg.Data.Defaults;
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

            return new DefaultClassTemplate
            {
                Id = ClassTypeLookups.Fighter,
                AssetCode = "class-fighter",
                NameLocaleId = "Fighter",
                DescriptionLocaleId = "Super tough, hits things",
                Effects = effects,
                Requirements = new List<Requirement>()
            };
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

            return new DefaultClassTemplate
            {
                Id = ClassTypeLookups.Mage,
                AssetCode = "class-mage",
                NameLocaleId = "Mage",
                DescriptionLocaleId = "Powerful magic users",
                Effects = effects,
                Requirements = new List<Requirement>()
            };
        }
    }
}