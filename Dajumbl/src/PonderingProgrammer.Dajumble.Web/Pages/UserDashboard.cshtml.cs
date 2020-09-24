using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PonderingProgrammer.Dajumble.Web.Pages
{
    public class UserDashboardModel : PageModel
    {
        public string UserName { get; set; }
        
        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login",new { area = "Identity" });
            }

            UserName = User.Identity.Name;
            
            return Page();
        }
    }
}