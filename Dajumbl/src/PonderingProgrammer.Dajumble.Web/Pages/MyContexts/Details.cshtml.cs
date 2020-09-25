using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Pages.MyContexts
{
    public class DetailsModel : PageModel
    {
        private readonly ContextRepository _repository;

        public DetailsModel(ContextRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Context Context { get; set; }

        public IActionResult OnGet(string contextKey)
        {
            Context = _repository.Get(User.Identity.Name, contextKey);
            if (Context == null) return NotFound();
            return Page();
        }
    }
}