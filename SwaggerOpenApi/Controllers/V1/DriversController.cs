using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwaggerOpenApi.Models;
using Microsoft.Net.Http.Headers;
using SwaggerOpenApi.Attributes;

namespace SwaggerOpenApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Produces("application/driver+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/driver+json")]
        public ActionResult<Driver> GetDriver()
        {
            return Ok(new Driver
            {
                Name = "Fernando Alonso",
                Country = "Spain"
            });
        }

        [HttpGet]
        [Route("")]
        [Produces("application/driverWithTeam+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/driverWithTeam+json")]
        public ActionResult<DriverWithTeam> GetDriverWithTeam()
        {
            return Ok(new DriverWithTeam
            {
                Name = "Fernando Alonso",
                Country = "Spain",
                Team = new Team
                {
                    Name = "Alpine" ,
                    Country = "France"
                }
            });
        }
    }
}
