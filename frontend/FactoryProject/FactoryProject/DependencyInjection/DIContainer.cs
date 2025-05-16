using FactoryProject.Contracts;
using FactoryProject.Infrastructure.Utilities.Services;
using FactoryProject.Services;

namespace FactoryProject.DependencyInjection;

public static class DIContaier
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IAuthService, AuthenticationManager>();
        services.AddScoped<ICartService, CartManager>();
        services.AddScoped<IPersonalService, PersonalManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IIngredientService, IngredientManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(Infrastructure.Utilities.Services.GenericStateService<>));
        services.AddScoped<ProductStateService>();
        services.AddScoped<PersonalStateService>();
        services.AddScoped<CategoryStateService>();
    }
}