namespace FactoryProject.Contracts;

public interface IUnitOfWork
{
    IAccountService AccountService { get; }
    IProductService ProductService { get; }
    ICategoryService CategoryService { get; }
    IAuthService AuthService { get; }
    IDepartmentService DepartmentService { get; }
    IIngredientService IngredientService { get; }
    IOrderService OrderService { get; }
    ICartService CartService { get; }
    IPersonalService PersonalService{ get;}
}
