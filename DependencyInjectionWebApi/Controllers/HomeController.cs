using DependencyInjectionWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGuidService guidService;
        private readonly ISingletonService service;
        private readonly ICustomLogger logger;

        public HomeController(IGuidService guidService, ISingletonService service, ICustomLogger logger)
        {
            this.guidService = guidService;
            this.service = service;
            this.logger = logger;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                Guid = guidService.GetGuid(),
                SingletonGuid = service.GetGuid()
            });
        }

        [HttpGet]
        [Route("logger")]
        public ActionResult GetLogger()
        {
            var result =
            new
            {
                Logger = logger.Log("Hello")
            };
            return Ok(result);
        }

        [HttpGet]
        [Route("greet")]
        public ActionResult Greet([FromServices] IGreetings greetingService)
        {
            return Ok(new
            {
                Greet = greetingService.greet("Aniket")
            });
        }

    }
}
