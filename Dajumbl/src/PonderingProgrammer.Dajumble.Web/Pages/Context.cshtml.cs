﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;
using PonderingProgrammer.Dajumble.Web.Rendering;

namespace PonderingProgrammer.Dajumble.Web.Pages
{
    public class ContextModel : PageModel
    {
        private readonly ContextRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public ContextModel(ContextRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Context Context { get; set; }
        public bool OwnedByCurrentUser { get; set; }
        public string ContextGraphviz { get; set; }

        public async Task<IActionResult> OnGetAsync(string ownerUserName, string contextKey)
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