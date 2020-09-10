﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenRpg.Demos.Web.Extensions;
using OpenRpg.Genres.Fantasy.Types;
using OpenRpg.Localization.Repositories;

namespace OpenRpg.Demos.Web.Infrastructure.OpenRpg.Locale
{
    public class DefaultLocaleRepository : LocaleRepository
    {
        public static readonly string EffectTextKey = "types-effects-";
        public static readonly string RequirementTextKey = "types-requirements-";
        public static readonly string ItemTypesTextKey = "types-item-type-";
        public static readonly string ItemQualityTextKey = "types-item-quality-";
        public static readonly string ModificationTextKey = "types-modification-";
        public static readonly string QuestStateTextKey = "types-quest-state-";
        public static readonly string ObjectivesTextKey = "types-objectives-";
        public static readonly string RewardsTextKey = "types-rewards-";
        public static readonly string DamageTypesTextKey = "types-damage-";
        public static readonly string AssociatedTypesTextKey = "types-associated-";
        
        public static string GetKeyFor(string typeKey, int typeValue)
        { return $"{typeKey}{typeValue}"; }

        public DefaultLocaleRepository()
        {
            LocaleCode = "en-gb";

            GenerateEffectLocaleText();
            GenerateRequirementLocaleText();
            GenerateItemTypeLocaleText();
            GenerateItemQualityTypeLocaleText();
            GenerateModificationTypeLocaleText();
            GenerateAssociatedTypeLocaleText();
            GenerateDamageTypeLocaleText();
            GenerateObjectiveTypeLocaleText();
            GenerateQuestStateTypeLocaleText();
            GenerateRewardTypeLocaleText();
        }

        private IDictionary<int, string> GetTypeFieldsDictionary<T>()
        { return GetTypeFieldsDictionary(typeof(T)); }

        private IDictionary<int, string> GetTypeFieldsDictionary(Type typeObject)
        {
            return typeObject
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(x => (int)x.GetValue(null), x => x.Name.UnPascalCase());
        }

        private void GenerateEffectLocaleText()
        {
            var effectWordRemovals = new[] { "Bonus", "Amount", "Percentage", "  " };
            GetTypeFieldsDictionary<EffectTypes>()
                    .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(EffectTextKey, key), value.ReplaceAll(effectWordRemovals, "")));
        }

        private void GenerateRequirementLocaleText()
        {
            GetTypeFieldsDictionary<RequirementTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(RequirementTextKey, key), value.Replace("Requirement", "")));
        }

        private void GenerateItemTypeLocaleText()
        {
            GetTypeFieldsDictionary<ItemTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(ItemTypesTextKey, key), value.Replace("Generic", "")));
        }

        private void GenerateItemQualityTypeLocaleText()
        {
            GetTypeFieldsDictionary<ItemQualityTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(ItemQualityTextKey, key), value));
        }

        private void GenerateModificationTypeLocaleText()
        {
            GetTypeFieldsDictionary<ModificationTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(ModificationTextKey, key), value.Replace("Modification", "s")));
        }

        private void GenerateQuestStateTypeLocaleText()
        {
            GetTypeFieldsDictionary<QuestStateTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(QuestStateTextKey, key), value));
        }

        private void GenerateObjectiveTypeLocaleText()
        {
            GetTypeFieldsDictionary<ObjectiveTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(ObjectivesTextKey, key), value.Replace("Objective", "")));
        }

        private void GenerateRewardTypeLocaleText()
        {
            GetTypeFieldsDictionary<RewardTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(RewardsTextKey, key), value.Replace("Reward", "")));
        }

        private void GenerateDamageTypeLocaleText()
        {
            GetTypeFieldsDictionary<DamageTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(DamageTypesTextKey, key), value));
        }

        private void GenerateAssociatedTypeLocaleText()
        {
            GetTypeFieldsDictionary<AssociatedTypes>()
                .ForEach((key, value) => LocaleDatastore.Add(GetKeyFor(AssociatedTypesTextKey, key), value.Replace("Association", "")));
        }
    }
}