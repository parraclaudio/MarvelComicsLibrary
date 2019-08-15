using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelComicsLibrary.Integration.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComicsLibrary.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelComicsController : ControllerBase
    {
        private readonly IMarvelApi _marvelApi;

        public MarvelComicsController(IMarvelApi marvelApi)
        {
            _marvelApi = marvelApi;
        }

        [HttpGet("{title}")]
        public IActionResult Get([FromRoute] string title)
        {
            return Ok(_marvelApi.GetComicByTitle(title));
        }
    }
}