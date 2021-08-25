using EnsureThat;
using Krystal.Services.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krystal.Services.Admin.Controllers
{
    public class LinkController : ControllerBase
    {
        private ILogger<LinkController> Logger { get; }

        public LinkController(ILogger<LinkController> logger)
        {
            Logger = EnsureArg.IsNotNull(logger);
        }

        [HttpGet("links")]
        public Task<List<Link>> GetLinks()
        {
            var result = new List<Link>();

            return Task.FromResult(result);
        }

        [HttpGet("links/{id}")]
        public Task<Link> GetById(Guid id)
        {
            Link result = null;

            return Task.FromResult(result);
        }

        [HttpPost("links")]
        public Task<Link> Create(Link model)
        {
            Link result = null;

            return Task.FromResult(result);
        }

        [HttpPost("links/{id}")]
        public Task<Link> Update(Guid id, Link model)
        {
            Link result = null;

            return Task.FromResult(result);
        }

        [HttpDelete("links/{id}")]
        public Task<bool> Delete(Guid id)
        {
            var result = false;

            return Task.FromResult(result);
        }
    }
}