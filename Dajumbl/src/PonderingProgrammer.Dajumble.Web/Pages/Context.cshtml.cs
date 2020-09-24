using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PonderingProgrammer.Dajumble.Web.Pages
{
    public class ContextModel : PageModel
    {
        public void OnGet()
        {
            
        }

        public ActionResult OnPostAsync()
        {
            return Page();
        }
        
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }
        }
    }
}