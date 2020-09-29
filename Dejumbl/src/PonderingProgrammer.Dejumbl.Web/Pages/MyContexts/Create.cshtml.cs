using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dejumbl.Web.Data;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web.Pages.MyContexts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ContextRepository _repository;

        public CreateModel(ApplicationDbContext dbContext, ContextRepository repository)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var error = ValidateUniqueContext(User.Identity.Name, Input.ContextKey);
                if (error != null) ModelState.AddModelError(string.Empty, error);
            }

            if (ModelState.IsValid)
            {
                var context = new Context(User.Identity.Name, Input.ContextKey) {Name = Input.Name, Description = Input.Description};
                _repository.Add(context);
                _dbContext.SaveChanges();
                return RedirectToPage($"/MyContexts/Details", new { contextKey = context.ContextKey });
            }
            
            return Page();
        }

        private string ValidateUniqueContext(string ownerUserName, string contextKey)
        {
            return _repository.Get(ownerUserName, contextKey) != null ? $"Context {ownerUserName}/{contextKey} already exists." : null;
        }

        public class InputModel : IValidatableObject
        {
            [Required]
            public string Name { get; set; }
            
            [Required]
            public string ContextKey { get; set; }
            
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                return Validators.ValidateForUrlFriendliness(ContextKey).Select(error => new ValidationResult(error, new [] { nameof(ContextKey) }));
            }
        }
    }
}