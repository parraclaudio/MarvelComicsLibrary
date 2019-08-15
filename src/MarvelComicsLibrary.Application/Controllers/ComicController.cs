using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using MarvelComicsLibrary.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComicsLibrary.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IComicService _service;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public ComicController(IMapper mapper, IComicService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<CustomerViewModel>> Get()
        {         
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public ActionResult<CustomerViewModel> Get(Guid key)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] CustomerViewModel obj)
        {
            return Ok(  );
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public ActionResult<ResponseRequest> Put(Guid key, [FromBody] CustomerViewModel obj)
        {    
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public ActionResult Delete(Guid key)
        {
            return Ok();
        }
    }
}
