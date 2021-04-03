using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreFundamentals.Pages
{
    public class ListModel : PageModel
    {
        private readonly IFormulaDataRepository formulaDataRepo;
        public IEnumerable<Team> Teams { get; set; }

        public ListModel(IFormulaDataRepository formulaDataRepo)
        {
            this.formulaDataRepo = formulaDataRepo;
        }
        public void OnGet()
        {
            Teams = this.formulaDataRepo.GetTeams();
        }
    }
}
