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
        public ActionResult<List<ResponseRequest>> Get()
        {
            var comicVM = _mapper.Map<List<ComicViewModel>>(_service.GetList());

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public ActionResult<ResponseRequest> Get(Guid key)
        {
            var comicVM = _mapper.Map<ComicViewModel>(_service.Find(key));

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] ComicViewModel obj)
        {
            var comic = _mapper.Map<Comic>(obj);

            var save = _service.Add(comic);

            var comicVM = _mapper.Map<ComicViewModel>(save);

            if (!comicVM.Valid)
            {
                return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
            }

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public ActionResult<ResponseRequest> Put(Guid key, [FromBody] ComicViewModel obj)
        {
            var dbComic = _service.Find(key);

            if (dbComic == null)
            {
                return BadRequest();
            }

            var comic = _mapper.Map<Comic>(obj);

            comic.Id = dbComic.Id;
            comic.Key = key;

            var update = _service.Amend(comic);

            var comicVM = _mapper.Map<ComicViewModel>(update);

            if (!comicVM.Valid)
            {
                return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
            }

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        [HttpPatch("Borrow")]
        public ActionResult<ResponseRequest> Patch(BorrowViewModel obj)
        {
            var dbComic = _service.Find(obj.ComicKey);

            if (dbComic == null)
            {
                return BadRequest();
            }

            var update = _service.BorrowComic(obj.CustomerKey, obj.ComicKey, obj.status);

            var comicVM = _mapper.Map<ComicViewModel>(update);

            if (!comicVM.Valid)
            {
                return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
            }

            return Ok(_mapper.Map<ResponseRequest>(comicVM));
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public ActionResult Delete(Guid key)
        {
            return Ok();
        }
    }
}
