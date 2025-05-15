using FactoryProject.Contracts;
using FactoryProject.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FactoryProject.Pages
{
    public class LogOutControlModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenContainer _tokenContainer;
        public string  ReturnUrl { get; set; }    
        public LogOutControlModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ReturnUrl = "/account/login";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _unitOfWork.AuthService.LogoutAsync();
            _tokenContainer.Token=string.Empty;
            return Redirect(ReturnUrl);
        }
    }
}
