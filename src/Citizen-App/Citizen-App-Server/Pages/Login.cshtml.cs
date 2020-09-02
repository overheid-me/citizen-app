using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Citizen_App_Server.Pages
{
    public class LoginModel : PageModel
    {
        public async Task OnGet(string redirectUri)
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties
            {
                RedirectUri = redirectUri
            });
        }
    }
}
