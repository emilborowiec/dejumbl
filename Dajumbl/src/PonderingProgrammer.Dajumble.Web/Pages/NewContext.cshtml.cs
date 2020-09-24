using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Pages
{
    public class NewContextModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ContextRepository _repository;

        public NewContextModel(ApplicationDbContext dbContext, ContextRepository repository)
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
                var context = new Context(User.GetUserId()) {Name = Input.Name, Description = Input.Description};
                _repository.Add(context);
                _dbContext.SaveChanges();
                return RedirectToPage($"/Context", new { id = context.Id });
            }
            return Page();
        }
        

        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }
        }
    }
}