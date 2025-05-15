using FactoryProject.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactoryProject.Pages
{
    [AllowAnonymous]
    public class LoginControlModel(IUnitOfWork unitOfWork,
        ILogger<LoginControlModel> logger) : PageModel
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<LoginControlModel> _logger=logger;
        public string? ReturnUrl { get; set; }
        [FromQuery]
        public string? Token { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {

                    ReturnUrl = Url.Content("/biscuits");
                    //var token = _sessionHandler.Get("tempToken");
                    await _unitOfWork.AuthService.SetAuthenticateAsync(Token);
                    return LocalRedirect(ReturnUrl);
                }
                else return Redirect("/account/login");

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return Redirect("/account/login");
            }
        }
    }
}
