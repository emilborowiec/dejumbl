using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Pages.MyItems
{
    public class DetailsModel : PageModel
    {
        private readonly ContextRepository _repository;

        public ContentItem ContentItem { get; set; }
        
        public IActionResult OnGet(string id)
        {
            var context = _repository.GetByContentItemId(id);
            ContentItem = context.Items.SingleOrDefault(i => i.Id == id);
            if (ContentItem == null) return NotFound();

            return Page();
        }
    }
}