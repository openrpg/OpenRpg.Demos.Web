﻿using System;
using System.Collections.Generic;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Modifications;
using OpenRpg.Core.Requirements;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;
using OpenRpg.Items.Extensions;
using OpenRpg.Items.Templates;

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
                MakeJunkPotion(),
                MakeCopperIngot(),
                MakeCopperOre(),
                MakeIronOre(),
                MakeOakLog(),
                MakeCopperSword()
            };
        }

        public IItemTemplate MakeRubbishSword()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.Sword,
                NameLocaleId = "Sword",
                DescriptionLocaleId = "A really bad looking sword, can slay things though",
                ItemType = FantasyItemTypes.GenericWeapon,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = new[]
                {
                    new Effect { EffectType = FantasyEffectTypes.DamageBonusAmount, Potency = 30.0f }
                }
            };
            template.Variables.QualityType(FantasyItemQualityTypes.JunkQuality);
            template.Variables.Value(10);
            template.Variables.AssetCode("sword");

            return template;
        }

        private IItemTemplate MakeSuperSword()
        {
            var swordEffects = new[]
            {
                new Effect { EffectType = FantasyEffectTypes.DamageBonusAmount, Potency = 765.5f },
                new Effect { EffectType = FantasyEffectTypes.StrengthBonusAmount, Potency = 20.0f },
                new Effect { EffectType = FantasyEffectTypes.DamageBonusPercentage, Potency = 10.0f },
                new Effect { EffectType = FantasyEffectTypes.ConstitutionBonusAmount, Potency = 15.0f },
                new Effect { EffectType = FantasyEffectTypes.DarkDefenseAmount, Potency = 15.0f }
            };

            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.SuperSword,
                NameLocaleId = "Super Sword",
                DescriptionLocaleId = "So fancy it could slice through stone",
                ItemType = FantasyItemTypes.GenericWeapon,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = swordEffects
            };
            template.Variables.QualityType(FantasyItemQualityTypes.EpicQuality);
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
                ItemType = FantasyItemTypes.Potions,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = new[]
                {
                new Effect { EffectType = FantasyEffectTypes.HealthRestoreAmount, Potency = 30.0f }
            }
            };
            template.Variables.QualityType(FantasyItemQualityTypes.UncommonQuality);
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
                ItemType = FantasyItemTypes.Potions,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = new[]
                {
                new Effect { EffectType = FantasyEffectTypes.HealthRestoreAmount, Potency = -5.0f }
            }
            };
            template.Variables.QualityType(FantasyItemQualityTypes.JunkQuality);
            template.Variables.Value(0);
            template.Variables.MaxStacks(5);
            template.Variables.AssetCode("potion-2");
            
            return template;
        }

        public IItemTemplate MakeCopperIngot()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.CopperIngot,
                NameLocaleId = "Copper Ingot",
                DescriptionLocaleId = "A block of refined copper",
                ItemType = FantasyItemTypes.GenericItem,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = Array.Empty<Effect>(),
            };
            template.Variables.QualityType(FantasyItemQualityTypes.CommonQuality);
            template.Variables.Value(5);
            template.Variables.MaxStacks(20);
            template.Variables.AssetCode("copper-ingot");
            
            return template;
        }

        public IItemTemplate MakeCopperOre()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.CopperOre,
                NameLocaleId = "Copper Ore",
                DescriptionLocaleId = "A chunk of raw copper ore",
                ItemType = FantasyItemTypes.GenericItem,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = Array.Empty<Effect>(),
            };
            template.Variables.QualityType(FantasyItemQualityTypes.CommonQuality);
            template.Variables.Value(1);
            template.Variables.MaxStacks(20);
            template.Variables.AssetCode("copper-ore");
            
            return template;
        }
        
        public IItemTemplate MakeIronOre()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.IronOre,
                NameLocaleId = "Iron Ore",
                DescriptionLocaleId = "A chunk of raw iron ore",
                ItemType = FantasyItemTypes.GenericItem,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = Array.Empty<Effect>(),
            };
            template.Variables.QualityType(FantasyItemQualityTypes.CommonQuality);
            template.Variables.Value(1);
            template.Variables.MaxStacks(20);
            template.Variables.AssetCode("iron-ore");
            
            return template;
        }

        public IItemTemplate MakeOakLog()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.OakLog,
                NameLocaleId = "Oak Log",
                DescriptionLocaleId = "A log cut from an Oak tree",
                ItemType = FantasyItemTypes.GenericItem,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = Array.Empty<Effect>(),
            };
            template.Variables.QualityType(FantasyItemQualityTypes.CommonQuality);
            template.Variables.Value(1);
            template.Variables.MaxStacks(20);
            template.Variables.AssetCode("oak-log");
            
            return template;
        }

        public IItemTemplate MakeCopperSword()
        {
            var template = new DefaultItemTemplate
            {
                Id = ItemTemplateLookups.CopperSword,
                NameLocaleId = "A crafted copper sword",
                DescriptionLocaleId = "An oak hilt with a copper blade",
                ItemType = FantasyItemTypes.GenericWeapon,
                ModificationAllowances = Array.Empty<ModificationAllowance>(),
                Requirements = Array.Empty<Requirement>(),
                Effects = new[]
                {
                    new Effect { EffectType = FantasyEffectTypes.DamageBonusAmount, Potency = 50 }
                }
            };
            template.Variables.QualityType(FantasyItemQualityTypes.CommonQuality);
            template.Variables.Value(50);
            template.Variables.MaxStacks(1);
            template.Variables.AssetCode("copper-sword");
            
            return template;
        }

    }
}