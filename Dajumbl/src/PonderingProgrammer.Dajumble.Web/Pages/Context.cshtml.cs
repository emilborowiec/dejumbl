using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

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
        public string OwnerUserName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var context = _repository.FindById(id);
            if (context == null)
            {
                return NotFound();
            }

            Context = context;
            OwnedByCurrentUser = context.OwnerUserId == User.GetUserId(); 
            if (OwnedByCurrentUser)
            {
                OwnerUserName = User.Identity.Name;
            }
            else
            {
                var ownerUser = await _userManager.FindByIdAsync(context.OwnerUserId);
                OwnerUserName = ownerUser?.UserName ?? "unknown user";
            }
            
            return Page();
        }
    }
}