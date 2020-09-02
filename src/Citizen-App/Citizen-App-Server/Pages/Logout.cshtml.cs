using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Citizen_App_Server.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task OnGet()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties { RedirectUri = "/" });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
