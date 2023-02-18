using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace CorsMVCClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string content;

        public HttpClient Http { get; }

        public IndexModel(ILogger<IndexModel> logger,IHttpClientFactory http)
        {
            _logger = logger;
            Http = http.CreateClient();
        }

        public void OnGet()
        {
        }

      public void OnPostWay2(string data)
        {
            var response = this.Http.GetAsync("http://localhost:58341/api/teams").Result;
            var result = response.Content.ReadAsStringAsync();
            content = result.Result;


        }
    }
}
