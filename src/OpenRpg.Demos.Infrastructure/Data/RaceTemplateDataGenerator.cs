using System.Collections.Generic;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Races;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;

namespace OpenRpg.Demos.Infrastructure.Data
{
    public class RaceTemplateDataGenerator : IDataGenerator<IRaceTemplate>
    {
        public IEnumerable<IRaceTemplate> GenerateData()
        {
            return new [] 
            {
                GenerateHumanTemplate(),
                GenerateElfTemplate(),
                GenerateDwarfTemplate(),
            };
        }

        public IRaceTemplate GenerateHumanTemplate()
        {
            var effects = new[]
            {
                new Effect {Potency = 10, EffectType = EffectTypes.AllAttributeBonusAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.PureDamageAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.PureDefenseAmount},
                new Effect {Potency = 1, EffectType = EffectTypes.DarkDamageAmount},
                new Effect {Potency = 5, EffectType = EffectTypes.DarkDefenseAmount},
                new Effect {Potency = 80, EffectType = EffectTypes.HealthBonusAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.MagicBonusAmount}
            };

            var raceTemplate = new DefaultRaceTemplate
            {
                Id = RaceTypeLookups.Human,
                NameLocaleId = "Human",
                DescriptionLocaleId = "Humans are the most common of all races",
                Effects = effects
            };
            raceTemplate.Variables.AssetCode("race-human");
            return raceTemplate;
        }

        public IRaceTemplate GenerateElfTemplate()
        {
            var effects = new[]
            {
                new Effect {Potency = 8, EffectType = EffectTypes.StrengthBonusAmount},
                new Effect {Potency = 12, EffectType = EffectTypes.DexterityBonusAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.ConstitutionBonusAmount},
                new Effect {Potency = 12, EffectType = EffectTypes.IntelligenceBonusAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.WisdomBonusAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.CharismaBonusAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.PureDamageAmount},
                new Effect {Potency = 7, EffectType = EffectTypes.PureDefenseAmount},
                new Effect {Potency = 5, EffectType = EffectTypes.DarkDamageAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.DarkDefenseAmount},
                new Effect {Potency = 70, EffectType = EffectTypes.HealthBonusAmount},
                new Effect {Potency = 30, EffectType = EffectTypes.MagicBonusAmount}
            };

            var raceTemplate = new DefaultRaceTemplate
            {
                Id = RaceTypeLookups.Elf,
                NameLocaleId = "Elf",
                DescriptionLocaleId = "Elves are pretty common, have pointy ears too",
                Effects = effects
            };
            raceTemplate.Variables.AssetCode("race-elf");
            return raceTemplate;
        }

        public IRaceTemplate GenerateDwarfTemplate()
        {
            var effects = new[]
            {
                new Effect {Potency = 12, EffectType = EffectTypes.StrengthBonusAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.DexterityBonusAmount},
                new Effect {Potency = 12, EffectType = EffectTypes.ConstitutionBonusAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.IntelligenceBonusAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.WisdomBonusAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.CharismaBonusAmount},
                new Effect {Potency = 8, EffectType = EffectTypes.PureDamageAmount},
                new Effect {Potency = 10, EffectType = EffectTypes.PureDefenseAmount},
                new Effect {Potency = 100, EffectType = EffectTypes.HealthBonusAmount},
                new Effect {Potency = -1, EffectType = EffectTypes.DarkDefenseAmount},

            };

            var raceTemplate = new DefaultRaceTemplate
            {
                Id = RaceTypeLookups.Dwarf,
                NameLocaleId = "Dwarf",
                DescriptionLocaleId = "Dwarves are strong and hardy",
                Effects = effects
            };
            raceTemplate.Variables.AssetCode("race-dwarf");
            return raceTemplate;
        }
    }
}