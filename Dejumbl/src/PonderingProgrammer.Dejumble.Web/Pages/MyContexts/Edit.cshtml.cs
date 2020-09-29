using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dejumble.Web.Data;

namespace PonderingProgrammer.Dejumble.Web.Pages.MyContexts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ContextRepository _repository;

        public EditModel(ApplicationDbContext dbContext, ContextRepository repository)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [BindProperty(SupportsGet = true)]
        public string ContextKey { get; set; }
        
        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
            var context = _repository.Get(User.Identity.Name, ContextKey);
            Input = new InputModel {Name = context.Name, Description = context.Description};
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            
            var context = _repository.Get(User.Identity.Name, ContextKey);
            context.Name = Input.Name;
            context.Description = Input.Description;
            _dbContext.SaveChanges();
            return RedirectToPage("/MyContexts/Details", new {contextKey = ContextKey});
        }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}