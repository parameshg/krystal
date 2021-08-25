using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Krystal.Services.Endpoint.Controllers
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

        [HttpGet]
        public DateTime Index()
        {
            Logger.LogWarning("No slug found. Use valid path for redirection.");

            return DateTime.Now;
        }

        [HttpGet("{slug}")]
        public IActionResult Index(string slug)
        {
            var longUrl = "https://www.paramg.com"; // TODO: Placeholder for real url

            return Redirect(longUrl);
        }
    }
}