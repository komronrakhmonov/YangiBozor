using YangiBozor.Data.IRepositories;
using YangiBozor.Data.Repositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.Interfaces;
using YangiBozor.Service.Services;

namespace YangiBozor.Web.Extensions;

public static class ServiceExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<IPaymentService, PaymentService>();
    }
}
