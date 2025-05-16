using FactoryProject.Contracts;
using FactoryProject.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FactoryProject.Pages
{
    public class LogOutControlModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenContainer _tokenContainer;
        public string  ReturnUrl { get; set; }    
        public LogOutControlModel(IUnitOfWork unitOfWork,TokenContainer tokenContainer)
        {
            _unitOfWork = unitOfWork;
            ReturnUrl = "/account/login";
            _tokenContainer = tokenContainer;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _unitOfWork.AuthService.LogoutAsync();
            _tokenContainer.Token=string.Empty;
            return Redirect(ReturnUrl);
        }
    }
}
