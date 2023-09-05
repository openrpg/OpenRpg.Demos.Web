using OpenRpg.Core.Races;
using OpenRpg.Core.Stats.Variables;
using OpenRpg.Data;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.Persistence.Characters;
using OpenRpg.Genres.Persistence.Classes;
using OpenRpg.Genres.Persistence.Items;
using OpenRpg.Genres.Persistence.Items.Equipment;
using OpenRpg.Genres.Persistence.Items.Inventory;

namespace OpenRpg.Demos.Infrastructure.Persistence;

public class DemoCharacterMapper : CharacterMapper
{
    public IRepository Repository { get; }

    public DemoCharacterMapper(IItemMapper itemMapper, IClassMapper classMapper, IEquipmentMapper equipmentMapper, IInventoryMapper inventoryMapper, IRepository repository) : base(itemMapper, classMapper, equipmentMapper, inventoryMapper)
    { Repository = repository; }

    public override IRaceTemplate GetRaceTemplateFor(int raceTemplateId)
    { return Repository.Get<IRaceTemplate>(raceTemplateId); }
}