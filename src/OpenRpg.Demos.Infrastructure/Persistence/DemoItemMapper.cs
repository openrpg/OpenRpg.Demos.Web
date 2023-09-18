using OpenRpg.Core.Modifications;
using OpenRpg.Data;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.Persistence.Items;
using OpenRpg.Items.Templates;

namespace OpenRpg.Demos.Infrastructure.Persistence;

public class DemoItemMapper : ItemMapper
{
    public IRepository Repository { get; }

    public DemoItemMapper(IRepository repository)
    { Repository = repository; }

    public override IItemTemplate GetItemTemplateFor(int itemTemplateId)
    { return Repository.Get<IItemTemplate>(itemTemplateId); }

    public override IModificationTemplate GetModificationsFor(int modificationId)
    { return Repository.Get<IModificationTemplate>(modificationId); }
}