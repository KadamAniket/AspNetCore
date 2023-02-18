using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerOpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerOpenApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TeamsController : ControllerBase
    {
        private readonly List<Team> _teams;
        public TeamsController()
        {
            _teams = new List<Team>
            {
                new Team { Name = "Ferrari", Country = "Italy",  Championships =12},
                new Team { Name = "Mclaren", Country = "UK",  Championships =9},
                new Team { Name = "Redbull", Country = "Asstria",  Championships =4}

            };
        }

        /// <summary>
        /// Get all the teams
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Team>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_teams);
        }


        /// <summary>
        /// Get team info based on name
        /// </summary>
        /// <param name="teamName">Team name</param>
        /// <returns>Team information</returns>
        [HttpGet]
        [Route("name")]
        [Produces("application/xml", "application/json")]
        [ProducesResponseType(typeof(Team), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Team> GetTeam(string teamName)
        {
            var team = _teams.Find(team => team.Name == teamName);
            if (team != null)
            {
                return Ok(team);
            }

            return NotFound();

        }

        /// <summary>
        /// Add new team
        /// </summary>
        /// <param name="team">Team</param>
        /// <returns></returns>
        /// <remarks>
        /// Team{
        /// Name= "Renault",
        /// Country ="India",
        /// Wins="2"
        /// }
        /// </remarks>
        [HttpPost]
        [Route("name")]
        public ActionResult Post(Team team)
        {
            if (team != null)
            {
                _teams.Add(team);
            }

            return BadRequest();

        }
    }
}
