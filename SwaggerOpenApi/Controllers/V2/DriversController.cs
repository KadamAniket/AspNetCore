using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwaggerOpenApi.Models;
using Microsoft.Net.Http.Headers;
using SwaggerOpenApi.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace SwaggerOpenApi.Controllers
{
    [Route("api/v{version:apiVersion}/drivers")]
    [ApiVersion("2.0")]
    [ApiController]
    public class DriversControllerV2 : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Produces("application/driver+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/driver+json")]
        public ActionResult<Driver> GetDriver()
        {
            return Ok(new Driver
            {
                Name = "Carlos Sainz",
                Country = "Spain"
            });
        }

        
    }
}
