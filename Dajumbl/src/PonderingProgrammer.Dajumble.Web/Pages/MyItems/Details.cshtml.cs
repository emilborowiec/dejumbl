using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Pages.MyItems
{
    public class DetailsModel : PageModel
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ApplicationDbContext _dbContext;
        private readonly ContextRepository _repository;

        public DetailsModel(IAuthorizationService authorizationService, ApplicationDbContext dbContext, ContextRepository repository)
        {
            _authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public ContentItem ContentItem { get; set; }
        public List<SelectListItem> TargetOptions { get; set; }
        public List<SelectListItem> RelationTypeOptions { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var context = _repository.GetByContentItemId(Id);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, context, "ContextOwnerPolicy");
            if (authorizationResult.Succeeded)
            {
                ContentItem = context.Items.SingleOrDefault(i => i.Id == Id);
                if (ContentItem == null) return NotFound();

                PopulateOptions(context);

                return Page();
            }
            if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }

            return new ChallengeResult();
        }

        private void PopulateOptions(Context context)
        {
            TargetOptions = context.Items.Where(item => item != ContentItem)
                                   .Select(item => new SelectListItem(item.Label, item.Id))
                                   .ToList();
            RelationTypeOptions = Enum.GetNames(typeof(RelationType))
                                      .Select(name => new SelectListItem(name, name))
                                      .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var context = _repository.GetByContentItemId(Id);
            
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, context, "ContextOwnerPolicy");
            if (authorizationResult.Succeeded)
            {
                ContentItem = context.Items.SingleOrDefault(i => i.Id == Id);
                if (ContentItem == null) return NotFound();
                
                var targetContentItem = context.Items.SingleOrDefault(i => i.Id == Input.TargetItemId);
                if (targetContentItem == null) ModelState.AddModelError(string.Empty, "Target content item was not found");

                if (!ModelState.IsValid) return Page();

                ContentItem.AddRelation(targetContentItem, Enum.Parse<RelationType>(Input.RelationType));
                await _dbContext.SaveChangesAsync();
                
                PopulateOptions(context);
                return Page();
            }
            if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }

            return new ChallengeResult();
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Target item")]
            public string TargetItemId { get; set; }
            [Display(Name = "Kind of relation")]
            public string RelationType { get; set; }
        }
    }
}