
using FactoryProject.Contracts;

namespace FactoryProject.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAccountService _accountService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthService _authService;

    public UnitOfWork(IAccountService accountService,
    IProductService productService,
     ICategoryService categoryService,
     IAuthService authService)
    {
        _accountService = accountService;
        _productService = productService;
        _categoryService = categoryService;
        _authService = authService;
    }

    public IAccountService AccountService => _accountService;
    public IProductService ProductService => _productService;
    public ICategoryService CategoryService => _categoryService;
    public IAuthService AuthService => _authService;
}
