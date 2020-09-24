using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PonderingProgrammer.Dajumble.Web.Pages
{
    public class UserDashboardModel : PageModel
    {
        public string UserName { get; set; }
        
        public void OnGet()
        {
            UserName = User.Identity.Name;
        }
    }
}