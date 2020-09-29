using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dejumbl.Web.Rendering;
using PonderingProgrammer.Dejumbl.Web.Data;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web.Pages
{
    public class ContextModel : PageModel
    {
        private readonly ContextRepository _repository;

        public ContextModel(ContextRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Context Context { get; set; }
        public bool OwnedByCurrentUser { get; set; }
        public string ContextGraphviz { get; set; }

        public IActionResult OnGet(string ownerUserName, string contextKey)
        {
            var context = _repository.GetWithRelations(ownerUserName, contextKey);
            if (context == null)
            {
                return NotFound();
            }

            Context = context;
            OwnedByCurrentUser = context.OwnerUserName == User.Identity.Name;
            ContextGraphviz = context.ToGraphviz();
            
            return Page();
        }
    }
}