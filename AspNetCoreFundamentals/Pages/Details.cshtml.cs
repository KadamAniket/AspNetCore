using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL;

namespace AspNetCoreFundamentals.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IFormulaDataRepository formulaDataRepository;

        public Team Team { get; set; }
        public DetailsModel(IFormulaDataRepository formulaDataRepository)
        {
            this.formulaDataRepository = formulaDataRepository;
        }

        public IActionResult OnGet(int teamId)
        {
            Team = formulaDataRepository.GetTeamById(teamId);
            if (Team != null)
            {
                return Page();
            }

            return RedirectToPage("NotFound");
        }
    }
}
