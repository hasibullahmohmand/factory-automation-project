namespace FactoryProject.Contracts;

public interface IUnitOfWork
{
    IAccountService AccountService { get; }
    IProductService ProductService { get; }
    ICategoryService CategoryService { get; }
    IAuthService AuthService { get; }
}