using System;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComicsLibrary.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.UtcNow);
        }
    }
}