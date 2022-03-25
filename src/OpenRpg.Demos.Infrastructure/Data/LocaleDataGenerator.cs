using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenRpg.Cards.Types;
using OpenRpg.Demos.Infrastructure.Data;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Demos.Infrastructure.Types;
using OpenRpg.Genres.Types;
using OpenRpg.Localization;
using OpenRpg.Localization.Data.Repositories;
using DamageTypes = OpenRpg.Genres.Fantasy.Types.DamageTypes;
using EffectTypes = OpenRpg.Genres.Fantasy.Types.EffectTypes;
using ItemQualityTypes = OpenRpg.Genres.Fantasy.Types.ItemQualityTypes;
using ItemTypes = OpenRpg.Genres.Fantasy.Types.ItemTypes;
using ModificationTypes = OpenRpg.Genres.Fantasy.Types.ModificationTypes;
using RequirementTypes = OpenRpg.Genres.Fantasy.Types.RequirementTypes;
using RewardTypes = OpenRpg.Genres.Fantasy.Types.RewardTypes;

namespace OpenRpg.Demos.Infrastructure.Locale
{
    public class LocaleDataGenerator : IDataGenerator<LocaleDataset>
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
        public static readonly string CardTypesTextKey = "types-cards-";
        public static readonly string UtilityTypesTextKey = "types-ai-utility-";
        public static readonly string AdviceTypesTextKey = "types-ai-advice-";
        
        public IEnumerable<LocaleDataset> GenerateData()
        {
            var localeDataset = new LocaleDataset { LocaleCode = "en-gb" };
            GenerateEffectLocaleText(localeDataset);
            GenerateRequirementLocaleText(localeDataset);
            GenerateItemTypeLocaleText(localeDataset);
            GenerateItemQualityTypeLocaleText(localeDataset);
            GenerateModificationTypeLocaleText(localeDataset);
            GenerateAssociatedTypeLocaleText(localeDataset);
            GenerateDamageTypeLocaleText(localeDataset);
            GenerateObjectiveTypeLocaleText(localeDataset);
            GenerateQuestStateTypeLocaleText(localeDataset);
            GenerateRewardTypeLocaleText(localeDataset);
            GenerateCardTypeLocaleText(localeDataset);
            GenerateUtilityTypeLocaleText(localeDataset);
            GenerateAdviceTypeLocaleText(localeDataset);

            return new[] { localeDataset };
        }
        
        public static string GetKeyFor(string typeKey, int typeValue)
        { return $"{typeKey}{typeValue}"; }

        private IDictionary<int, string> GetTypeFieldsDictionary<T>()
        { return GetTypeFieldsDictionary(typeof(T)); }

        private IDictionary<int, string> GetTypeFieldsDictionary(Type typeObject)
        {
            return typeObject
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .ToDictionary(x => (int)x.GetValue(null), x => x.Name.UnPascalCase());
        }

        public void GenerateEffectLocaleText(LocaleDataset localeDataset)
        {
            var effectWordRemovals = new[] { "Bonus", "Amount", "Percentage", "  " };
            GetTypeFieldsDictionary<EffectTypes>()
                    .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(EffectTextKey, key), value.ReplaceAll(effectWordRemovals, "")));
        }

        public void GenerateRequirementLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<RequirementTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(RequirementTextKey, key), value.Replace("Requirement", "")));
        }

        public void GenerateItemTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<ItemTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(ItemTypesTextKey, key), value.Replace("Generic", "")));
        }

        public void GenerateItemQualityTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<ItemQualityTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(ItemQualityTextKey, key), value));
        }

        public void GenerateModificationTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<ModificationTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(ModificationTextKey, key), value.Replace("Modification", "s")));
        }

        public void GenerateQuestStateTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<QuestStateTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(QuestStateTextKey, key), value));
        }

        public void GenerateObjectiveTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<ObjectiveTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(ObjectivesTextKey, key), value.Replace("Objective", "")));
        }

        public void GenerateRewardTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<RewardTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(RewardsTextKey, key), value.Replace("Reward", "")));
        }

        public void GenerateDamageTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<DamageTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(DamageTypesTextKey, key), value));
        }

        public void GenerateAssociatedTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<AssociatedTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(AssociatedTypesTextKey, key), value.Replace("Association", "")));
        }
        
        public void GenerateCardTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<CardTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(CardTypesTextKey, key), value.Replace("Card", "")));
        }
        
        public void GenerateUtilityTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<UtilityVariableTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(UtilityTypesTextKey, key), value));
        }
        
        public void GenerateAdviceTypeLocaleText(LocaleDataset localeDataset)
        {
            GetTypeFieldsDictionary<AdviceVariableTypes>()
                .ForEach((key, value) => localeDataset.LocaleData.Add(GetKeyFor(AdviceTypesTextKey, key), value));
        }
    }
}