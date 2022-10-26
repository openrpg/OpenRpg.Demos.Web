using OpenRpg.Core.Classes;
using OpenRpg.Data;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.Persistence.Classes;

namespace OpenRpg.Demos.Infrastructure.Persistence;

public class DemoClassMapper : ClassMapper
{
    public IRepository Repository { get; }

    public DemoClassMapper(IRepository repository)
    { Repository = repository; }
    
    public override IClassTemplate GetClassTemplateFor(int classTemplateId)
    { return Repository.Get<IClassTemplate>(classTemplateId); }
}