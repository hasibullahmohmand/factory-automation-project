
using FactoryProject.Contracts;

namespace FactoryProject.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAccountService _accountService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthService _authService;
    private readonly ICartService _cartService;
    private readonly IIngredientService _ingredientService;
    private readonly IDepartmentService _departmentService;
    private readonly IOrderService _orderService;
    private readonly IPersonalService _personalServie;

    public UnitOfWork(IAccountService accountService,
    IProductService productService,
     ICategoryService categoryService,
     IAuthService authService,
     ICartService cartService,
     IIngredientService ingredientService,
     IDepartmentService departmentService,
     IOrderService orderService,
     IPersonalService personalServie)
    {
        _accountService = accountService;
        _productService = productService;
        _categoryService = categoryService;
        _authService = authService;
        _cartService = cartService;
        _ingredientService = ingredientService;
        _departmentService = departmentService;
        _orderService = orderService;
        _personalServie = personalServie;
    }

    public IAccountService AccountService => _accountService;
    public IProductService ProductService => _productService;
    public ICategoryService CategoryService => _categoryService;
    public IAuthService AuthService => _authService;
    public IDepartmentService DepartmentService => _departmentService;
    public IIngredientService IngredientService => _ingredientService;
    public IOrderService OrderService => _orderService;
    public ICartService CartService => _cartService;
    public IPersonalService PersonalService => _personalServie;
}
