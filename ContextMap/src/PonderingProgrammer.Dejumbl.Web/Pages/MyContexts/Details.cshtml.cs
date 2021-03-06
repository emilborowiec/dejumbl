﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dejumbl.Web.Data;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web.Pages.MyContexts
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
            Context = _repository.GetWithRelations(User.Identity.Name, contextKey);
            if (Context == null) return NotFound();
            return Page();
        }
    }
}