using System.Collections.Generic;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Modifications;
using OpenRpg.Core.Requirements;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;
using OpenRpg.Items.Extensions;
using OpenRpg.Items.Templates;
using ItemTypes = OpenRpg.Genres.Fantasy.Types.ItemTypes;

namespace OpenRpg.Demos.Infrastructure.Data
{
    public class ItemTemplateDataGenerator : IDataGenerator<IItemTemplate>
    {
        public IEnumerable<IItemTemplate> GenerateData()
        {
            return new []
            {
                MakeRubbishSword(),
                MakeSuperSword(),
                MakePotion(),
                MakeJunkPotion()
            };
        }

        public IItemTemplate MakeRubbishSword()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.Sword,
                NameLocaleId = "Sword",
                DescriptionLocaleId = "A really bad looking sword, can slay things though",
                ItemType = ItemTypes.GenericWeapon,
                ModificationAllowances = new ModificationAllowance[0],
                Requirements = new Requirement[0],
                Effects = new[]
                {
                new Effect { EffectType = EffectTypes.DamageBonusAmount, Potency = 30.0f }
            }
            };
            template.Variables.QualityType(ItemQualityTypes.JunkQuality);
            template.Variables.Value(10);
            template.Variables.AssetCode("sword");

            return template;
        }

        private IItemTemplate MakeSuperSword()
        {
            var swordEffects = new[]
            {
                new Effect { EffectType = EffectTypes.DamageBonusAmount, Potency = 765.5f },
                new Effect { EffectType = EffectTypes.StrengthBonusAmount, Potency = 20.0f },
                new Effect { EffectType = EffectTypes.DamageBonusPercentage, Potency = 10.0f },
                new Effect { EffectType = EffectTypes.ConstitutionBonusAmount, Potency = 15.0f },
                new Effect { EffectType = EffectTypes.DarkDefenseAmount, Potency = 15.0f }
            };

            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.SuperSword,
                NameLocaleId = "Super Sword",
                DescriptionLocaleId = "So fancy it could slice through stone",
                ItemType = ItemTypes.GenericWeapon,
                ModificationAllowances = new ModificationAllowance[0],
                Requirements = new Requirement[0],
                Effects = swordEffects
            };
            template.Variables.QualityType(ItemQualityTypes.EpicQuality);
            template.Variables.Value(10000);
            template.Variables.AssetCode("sword");
            
            return template;
        }

        public IItemTemplate MakePotion()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.HealingPotion,
                NameLocaleId = "Healing Potion",
                DescriptionLocaleId = "A sketchy looking potion, lets hope it heals you",
                ItemType = ItemTypes.Potions,
                ModificationAllowances = new ModificationAllowance[0],
                Requirements = new Requirement[0],
                Effects = new[]
                {
                new Effect { EffectType = EffectTypes.HealthRestoreAmount, Potency = 30.0f }
            }
            };
            template.Variables.QualityType(ItemQualityTypes.UncommonQuality);
            template.Variables.Value(20);
            template.Variables.MaxStacks(5);
            template.Variables.AssetCode("potion");

            return template;
        }

        public IItemTemplate MakeJunkPotion()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.JunkPotion,
                NameLocaleId = "Junk Potion Combi-Deal",
                DescriptionLocaleId = "Who knows whats in this...",
                ItemType = ItemTypes.Potions,
                ModificationAllowances = new ModificationAllowance[0],
                Requirements = new Requirement[0],
                Effects = new[]
                {
                new Effect { EffectType = EffectTypes.HealthRestoreAmount, Potency = -5.0f }
            }
            };
            template.Variables.QualityType(ItemQualityTypes.JunkQuality);
            template.Variables.Value(0);
            template.Variables.MaxStacks(5);
            template.Variables.AssetCode("potion-2");
            
            return template;
        }


    }
}