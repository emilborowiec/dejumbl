using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PonderingProgrammer.Dejumbl.Web.Data;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web.Pages.MyItems
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

        [BindProperty(SupportsGet = true)]
        public string ContextKey { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public List<SelectListItem> ItemTypeOptions { get; set; }

        public void OnGet(string contextKey)
        {
            ItemTypeOptions = Enum.GetNames(typeof(ContentItemType))
                                  .Select(type => new SelectListItem(type, type))
                                  .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var newItem = new ContentItem
            {
                ItemType = Enum.Parse<ContentItemType>(Input.ItemType), 
                Label = Input.Label, 
                Content = Input.Content,
            };
            var context = _repository.Get(User.Identity.Name, ContextKey);
            context.AddItem(newItem);
            _dbContext.SaveChanges();

            return RedirectToPage("/MyContexts/Details", new {contextKey = ContextKey});
        }

        public class InputModel
        {
            [Required]
            public string ItemType { get; set; }
            [Required]
            public string Label { get; set; }
            [DataType(DataType.MultilineText)]
            public string Content { get; set; }
        }
    }
}