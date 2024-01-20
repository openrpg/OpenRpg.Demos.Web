using System.Collections.Generic;
using System.Linq;
using OpenRpg.Core.Requirements;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;
using OpenRpg.Items.Templates;
using OpenRpg.Items.TradeSkills;
using OpenRpg.Items.TradeSkills.Extensions;
using OpenRpg.Items.TradeSkills.Gathering;
using OpenRpg.Items.TradeSkills.Types;

namespace OpenRpg.Demos.Infrastructure.Data
{
    public class GatheringTemplateDataGenerator : IDataGenerator<ItemGatheringTemplate>
    {
        public List<IItemTemplate> ItemTemplates { get; }

        public GatheringTemplateDataGenerator(List<IItemTemplate> itemTemplates)
        {
            ItemTemplates = itemTemplates;
        }

        public IEnumerable<ItemGatheringTemplate> GenerateData()
        {
            return new []
            {
                MakeCopperOreGatheringTemplate(),
                MakeIronOreGatheringTemplate(),
                MakeOakLogGatheringTemplate(),
            };
        }

        public ItemGatheringTemplate MakeCopperOreGatheringTemplate()
        {
            var itemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.CopperOre);
            var itemEntry = new TradeSkillItemEntry() { Template = itemTemplate };
            itemEntry.Variables.Amount(1);
        
            return new ItemGatheringTemplate()
            {
                Id = ItemGatheringTemplateLookups.CopperOre,
                SkillType = FantasyTradeSkillTypes.Mining,
                SkillDifficulty = 5,
                TimeToComplete = 1.0f,
                OutputItems = new List<TradeSkillItemEntry>() { itemEntry }
            };
        }
        
        public ItemGatheringTemplate MakeIronOreGatheringTemplate()
        {
            var itemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.IronOre);
            var itemEntry = new TradeSkillItemEntry() { Template = itemTemplate };
            itemEntry.Variables.Amount(1);
        
            return new ItemGatheringTemplate()
            {
                Id = ItemGatheringTemplateLookups.IronOre,
                SkillType = FantasyTradeSkillTypes.Mining,
                SkillDifficulty = 15,
                TimeToComplete = 1.0f,
                OutputItems = new List<TradeSkillItemEntry>() { itemEntry },
                Requirements =  new []
                {
                    new Requirement { RequirementType = FantasyRequirementTypes.TradeSkillRequirement, AssociatedId = FantasyTradeSkillTypes.Mining, AssociatedValue = 10 }
                },
            };
        }

        public ItemGatheringTemplate MakeOakLogGatheringTemplate()
        {
            var itemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.OakLog);
            var itemEntry = new TradeSkillItemEntry() { Template = itemTemplate };
            itemEntry.Variables.Amount(1);
        
            return new ItemGatheringTemplate()
            {
                Id = ItemGatheringTemplateLookups.OakLog,
                SkillType = FantasyTradeSkillTypes.Logging,
                SkillDifficulty = 0,
                TimeToComplete = 1.0f,
                OutputItems = new List<TradeSkillItemEntry>() { itemEntry }
            };
        }

    }
}