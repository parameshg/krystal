using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Krystal.Services.Analytics.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ILogger<HomeController> Logger { get; }

        public HomeController(ILogger<HomeController> logger)
        {
            Logger = EnsureArg.IsNotNull(logger);
        }

        [HttpGet("")]
        public string Index()
        {
            return "Krystal Analytics Services";
        }
    }
}