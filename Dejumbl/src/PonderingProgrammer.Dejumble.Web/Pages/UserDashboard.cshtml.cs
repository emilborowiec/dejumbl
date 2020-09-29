using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dejumble.Web.Data;
using PonderingProgrammer.Dejumble.Web.Model;

namespace PonderingProgrammer.Dejumble.Web.Pages
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