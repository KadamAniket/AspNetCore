using DependencyInjectionWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace DependencyInjectionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IEnumerable<ICustomLogger> loggers;

        public LogController(IEnumerable<ICustomLogger> loggers)
        {
            this.loggers = loggers;
        }


        [HttpGet]
        [Route("")]
        public ActionResult GetAllLogger()
        {
            var result =
            new
            {
                Logger = loggers.Select(m=> m.Log("Hello"))
            };
            return Ok(result);
        }
    }
}
