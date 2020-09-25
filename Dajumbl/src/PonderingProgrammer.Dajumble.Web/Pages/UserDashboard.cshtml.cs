using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.Dajumble.Web.Data;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Pages
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