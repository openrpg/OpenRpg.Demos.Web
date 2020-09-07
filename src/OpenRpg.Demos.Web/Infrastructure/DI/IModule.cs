using Microsoft.Extensions.DependencyInjection;

namespace OpenRpg.Demos.Web.Infrastructure.DI
{
    public interface IModule
    {
        void Setup(IServiceCollection services);
    }
}