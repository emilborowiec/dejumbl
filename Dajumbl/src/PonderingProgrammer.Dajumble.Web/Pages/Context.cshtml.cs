using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Pages
{
    public class ContextModel : PageModel
    {
        private readonly ContextRepository _repository;

        public ContextModel(ContextRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Context Context { get; set; }

        public IActionResult OnGet(string id)
        {
            var context = _repository.FindById(id);
            if (context == null)
            {
                return NotFound();
            }

            Context = context;
            
            return Page();
        }
    }
}