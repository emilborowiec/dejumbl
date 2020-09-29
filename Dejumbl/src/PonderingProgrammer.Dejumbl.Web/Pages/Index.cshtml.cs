using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.Dejumbl.Web.Data;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ContextRepository _contextRepository;

        public IndexModel(ILogger<IndexModel> logger, ContextRepository contextRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contextRepository = contextRepository ?? throw new ArgumentNullException(nameof(contextRepository));
        }

        public List<Context> Contexts { get; set; }

        public void OnGet()
        {
            Contexts = _contextRepository.GetAll();
        }
    }
}