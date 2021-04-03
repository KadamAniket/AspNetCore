using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger,IGuidService guidService)
        {
            _logger = logger;
            GuidService = guidService;
        }

        public IGuidService GuidService { get; }

        public void OnGet()
        {

        }
    }
}
