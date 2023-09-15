using System.Collections.Generic;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Effects;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;

namespace OpenRpg.Demos.Infrastructure.Data
{
    public class ClassTemplateDataGenerator : IDataGenerator<IClassTemplate>
    {
        public IEnumerable<IClassTemplate> GenerateData()
        {
            return new []
            {
                GenerateFighterClass(),
                GenerateMageClass()
            };
        }

        public IClassTemplate GenerateFighterClass()
        {
            var effects = new[]
            {
                new Effect {Potency = 2, EffectType = FantasyEffectTypes.StrengthBonusAmount},
                new Effect {Potency = 2, EffectType = FantasyEffectTypes.ConstitutionBonusAmount},
                new Effect {Potency = 5, EffectType = FantasyEffectTypes.DamageBonusAmount},
                new Effect {Potency = 5, EffectType = FantasyEffectTypes.DefenseBonusAmount},
                new Effect {Potency = 30, EffectType = FantasyEffectTypes.HealthBonusAmount}
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

        public IClassTemplate GenerateMageClass()
        {
            var effects = new[]
            {
                new Effect {Potency = 4, EffectType = FantasyEffectTypes.IntelligenceBonusAmount},
                new Effect {Potency = 10, EffectType = FantasyEffectTypes.DarkDamageAmount},
                new Effect {Potency = 10, EffectType = FantasyEffectTypes.DarkDefenseAmount},
                new Effect {Potency = 30, EffectType = FantasyEffectTypes.MagicBonusAmount}
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