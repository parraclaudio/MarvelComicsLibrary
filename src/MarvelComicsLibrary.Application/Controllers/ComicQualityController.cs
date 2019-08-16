using System;
using System.Collections.Generic;
using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using MarvelComicsLibrary.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComicsLibrary.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComicQualityController : ControllerBase
    {
        private readonly IComicQualityService _service;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public ComicQualityController(IMapper mapper, IComicQualityService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ResponseRequest>> Get()
        {
            var comicVM = _mapper.Map<List<ComicQualityViewModel>>(_service.GetList());

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public ActionResult<ResponseRequest> Get(Guid key)
        {
            var comicVM = _mapper.Map<ComicQualityViewModel>(_service.Find(key));

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] ComicQualityViewModel obj)
        {
            var comic = _mapper.Map<ComicQuality>(obj);

            var save = _service.Add(comic);

            var comicVM = _mapper.Map<ComicQualityViewModel>(save);

            if (!comicVM.Valid)
            {
                return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
            }

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }
    }
}
