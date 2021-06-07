using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenRpg.Cards.Types;
using OpenRpg.Demos.Infrastructure.Extensions;
using OpenRpg.Genres.Fantasy.Types;
using OpenRpg.Localization;
using OpenRpg.Localization.Repositories;

namespace OpenRpg.Demos.Infrastructure.Locale
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
        public static readonly string CardTypesTextKey = "types-cards-";
        
        public static string GetKeyFor(string typeKey, int typeValue)
        { return $"{typeKey}{typeValue}"; }

        public DefaultLocaleRepository() : base(new LocaleDataset())
        {
            LocaleDataset.LocaleCode = "en-gb";

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
            GenerateCardTypeLocaleText();
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
                    .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(EffectTextKey, key), value.ReplaceAll(effectWordRemovals, "")));
        }

        private void GenerateRequirementLocaleText()
        {
            GetTypeFieldsDictionary<RequirementTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(RequirementTextKey, key), value.Replace("Requirement", "")));
        }

        private void GenerateItemTypeLocaleText()
        {
            GetTypeFieldsDictionary<ItemTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(ItemTypesTextKey, key), value.Replace("Generic", "")));
        }

        private void GenerateItemQualityTypeLocaleText()
        {
            GetTypeFieldsDictionary<ItemQualityTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(ItemQualityTextKey, key), value));
        }

        private void GenerateModificationTypeLocaleText()
        {
            GetTypeFieldsDictionary<ModificationTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(ModificationTextKey, key), value.Replace("Modification", "s")));
        }

        private void GenerateQuestStateTypeLocaleText()
        {
            GetTypeFieldsDictionary<QuestStateTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(QuestStateTextKey, key), value));
        }

        private void GenerateObjectiveTypeLocaleText()
        {
            GetTypeFieldsDictionary<ObjectiveTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(ObjectivesTextKey, key), value.Replace("Objective", "")));
        }

        private void GenerateRewardTypeLocaleText()
        {
            GetTypeFieldsDictionary<RewardTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(RewardsTextKey, key), value.Replace("Reward", "")));
        }

        private void GenerateDamageTypeLocaleText()
        {
            GetTypeFieldsDictionary<DamageTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(DamageTypesTextKey, key), value));
        }

        private void GenerateAssociatedTypeLocaleText()
        {
            GetTypeFieldsDictionary<AssociatedTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(AssociatedTypesTextKey, key), value.Replace("Association", "")));
        }
        
        private void GenerateCardTypeLocaleText()
        {
            GetTypeFieldsDictionary<CardTypes>()
                .ForEach((key, value) => LocaleDataset.LocaleData.Add(GetKeyFor(CardTypesTextKey, key), value.Replace("Card", "")));
        }
    }
}