using DependencyInjectionWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGuidService guidService;

        public HomeController(IGuidService guidService)
        {
            this.guidService = guidService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { Guid = guidService.GetGuid() });
        }
    }
}
