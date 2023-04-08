using YangiBozor.Data.IRepositories;
using YangiBozor.Data.Repositories;

namespace YangiBozor.Web.Extensions;

public static class ServiceExtension
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
