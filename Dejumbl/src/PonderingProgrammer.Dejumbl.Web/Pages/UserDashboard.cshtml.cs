using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dejumbl.Web.Data;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web.Pages
{
    public class UserDashboardModel : PageModel
    {
        private readonly ContextRepository _contextRepository;

        public UserDashboardModel(ContextRepository contextRepository)
        {
            _contextRepository = contextRepository ?? throw new ArgumentNullException(nameof(contextRepository));
        }

        public string UserName { get; set; }
        public List<Context> Contexts { get; set; }
        
        public void OnGet()
        {
            UserName = User.Identity.Name;
            Contexts = _contextRepository.FindUserOwnedContexts(User.Identity.Name);
        }
    }
}