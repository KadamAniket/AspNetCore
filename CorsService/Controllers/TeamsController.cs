using CorsService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CorsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Team>> Get()
        {
            var teams = new List<Team>
            {
                new Team { Name ="Ferrari",Country ="Italy",ConstructorChampionShips =15, DriverChampionShips = 9},
                new Team { Name ="Alpine",Country ="France",ConstructorChampionShips =2, DriverChampionShips = 2},
                new Team { Name ="Mclaren",Country ="United Kingdom",ConstructorChampionShips =5, DriverChampionShips = 6},
                new Team { Name ="Mercedes",Country ="Germany",ConstructorChampionShips =9, DriverChampionShips = 9}

            };

            return Ok(teams);
        }
    }
}
