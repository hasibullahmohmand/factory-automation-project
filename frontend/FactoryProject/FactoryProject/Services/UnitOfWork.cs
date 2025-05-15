
using FactoryProject.Contracts;

namespace FactoryProject.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAccountService _accountService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthService _authService;
    private readonly ICartService _cartService;

    public UnitOfWork(IAccountService accountService,
    IProductService productService,
     ICategoryService categoryService,
     IAuthService authService,
     ICartService cartService)
    {
        _accountService = accountService;
        _productService = productService;
        _categoryService = categoryService;
        _authService = authService;
        _cartService = cartService;
    }

    public IAccountService AccountService => _accountService;
    public IProductService ProductService => _productService;
    public ICategoryService CategoryService => _categoryService;
    public IAuthService AuthService => _authService;

    public ICartService CartService => _cartService;
}
