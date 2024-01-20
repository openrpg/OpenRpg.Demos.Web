using System.Collections.Generic;
using System.Linq;
using OpenRpg.Demos.Infrastructure.Lookups;
using OpenRpg.Genres.Fantasy.Types;
using OpenRpg.Items.Templates;
using OpenRpg.Items.TradeSkills;
using OpenRpg.Items.TradeSkills.Crafting;
using OpenRpg.Items.TradeSkills.Extensions;
using OpenRpg.Items.TradeSkills.Gathering;

namespace OpenRpg.Demos.Infrastructure.Data;

public class CraftingTemplateDataGenerator : IDataGenerator<ItemCraftingTemplate>
{
    public List<IItemTemplate> ItemTemplates { get; }

    public CraftingTemplateDataGenerator(List<IItemTemplate> itemTemplates)
    {
        ItemTemplates = itemTemplates;
    }

    public IEnumerable<ItemCraftingTemplate> GenerateData()
    {
        return new []
        {
            MakeCopperIngotCraftingTemplate(),
            MakeCopperSwordCraftingTemplate()
        };
    }

    public ItemCraftingTemplate MakeCopperIngotCraftingTemplate()
    {
        var oreItemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.CopperOre);
        var ingotItemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.CopperIngot);
        var inputItemEntry = new TradeSkillItemEntry() { Template = oreItemTemplate };
        inputItemEntry.Variables.Amount(5);

        var outputItemEntry = new TradeSkillItemEntry() { Template = ingotItemTemplate };
        outputItemEntry.Variables.Amount(1);
        
        return new ItemCraftingTemplate()
        {
            Id = ItemCraftingTemplateLookups.CopperIngot,
            SkillType = FantasyTradeSkillTypes.Smelting,
            SkillDifficulty = 0,
            TimeToComplete = 2.0f,
            InputItems = new List<TradeSkillItemEntry>() { inputItemEntry },
            OutputItems = new List<TradeSkillItemEntry>() { outputItemEntry }
        };
    }

    public ItemCraftingTemplate MakeCopperSwordCraftingTemplate()
    {
        var ingotItemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.CopperIngot);
        var oakLogTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.OakLog);
        var swordItemTemplate = ItemTemplates.SingleOrDefault(x => x.Id == ItemTemplateLookups.CopperSword);
        var inputItem1Entry = new TradeSkillItemEntry() { Template = ingotItemTemplate };
        inputItem1Entry.Variables.Amount(2);
        var inputItem2Entry = new TradeSkillItemEntry() { Template = oakLogTemplate };
        inputItem2Entry.Variables.Amount(1);

        var outputItemEntry = new TradeSkillItemEntry() { Template = swordItemTemplate };
        outputItemEntry.Variables.Amount(1);
        
        return new ItemCraftingTemplate()
        {
            Id = ItemCraftingTemplateLookups.CopperSword,
            SkillType = FantasyTradeSkillTypes.Smithing,
            SkillDifficulty = 0,
            TimeToComplete = 2.0f,
            InputItems = new List<TradeSkillItemEntry>() { inputItem1Entry, inputItem2Entry },
            OutputItems = new List<TradeSkillItemEntry>() { outputItemEntry }
        };
    }
}