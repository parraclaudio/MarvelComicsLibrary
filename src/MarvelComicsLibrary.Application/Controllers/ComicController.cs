using System;
using System.Collections.Generic;
using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarvelComicsLibrary.Application.Controllers
{
    /// <summary>
    ///  API Controller for Comic Domain
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ComicController> _logger;
        private readonly IComicService _service;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="logger">Serilog</param>
        /// <param name="service">Comic Service</param>
        public ComicController(IMapper mapper, ILogger<ComicController> logger, IComicService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Fetch Comic List
        /// </summary>
        /// <returns type="ResponseRequest"></returns>
        [HttpGet]
        public ActionResult<List<ResponseRequest>> Get()
        {
            try
            {
                _logger.LogInformation("GET Received");

                var comicVM = _mapper.Map<List<ComicViewModel>>(_service.GetList());

                return Ok(_mapper.Map<ResponseRequest>(comicVM));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Fecth a Comic by Key
        /// </summary>
        /// <param name="key">Comic ID</param>
        [HttpGet("{key}")]
        public ActionResult<ResponseRequest> Get(Guid key)
        {
            try
            {
                _logger.LogInformation("Received GET");

                var comicVM = _mapper.Map<ComicViewModel>(_service.Find(key));

                return Ok(_mapper.Map<ResponseRequest>(comicVM));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        ///  Create new Comic
        /// </summary>
        /// <param name="obj">ComicViewModel</param>
        /// <returns>ResponseRequest</returns>
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] ComicViewModel obj)
        {
            try
            {
                _logger.LogInformation("Received POST : {@data}", obj);

                var comic = _mapper.Map<Comic>(obj);

                var save = _service.Add(comic);

                var comicVM = _mapper.Map<ComicViewModel>(save);

                if (!comicVM.Valid)
                {
                    _logger.LogInformation("POST Invalid : {@data}", comicVM);

                    return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
                }

                return Ok(_mapper.Map<ResponseRequest>(comicVM));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Update a Comic by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut("{key}")]
        public ActionResult<ResponseRequest> Put(Guid key, [FromBody] ComicViewModel obj)
        {
            try
            {
                _logger.LogInformation("Received PUT : {@data}", obj);

                var dbComic = _service.Find(key);

                if (dbComic == null)
                {
                    _logger.LogInformation("Invalid PUT : {@data}", obj);

                    return BadRequest("Comic Not Found");
                }

                var comic = _mapper.Map<Comic>(obj);

                comic.Id = dbComic.Id;
                comic.Key = key;

                var update = _service.Amend(comic);

                var comicVM = _mapper.Map<ComicViewModel>(update);

                if (!comicVM.Valid)
                {
                    _logger.LogInformation("Invalid PUT : {@data}", obj);

                    return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
                }

                return Ok(_mapper.Map<ResponseRequest>(comicVM));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Borrow a comic , set same attributes of Comic entity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPatch("Borrow")]
        public ActionResult<ResponseRequest> Patch(BorrowViewModel obj)
        {
            try
            {
                _logger.LogInformation("Received PATCH : {@data}", obj);

                var dbComic = _service.Find(obj.ComicKey);

                if (dbComic == null)
                {
                    _logger.LogInformation("Invalid PATCH :  Comic Not Found");
                    return BadRequest("Comic Not Found");
                }

                var update = _service.BorrowComic(obj.CustomerKey, obj.ComicKey, obj.status);

                var comicVM = _mapper.Map<ComicViewModel>(update);

                if (!comicVM.Valid)
                {
                    return BadRequest(_mapper.Map<ResponseRequest>(comicVM));
                }

                return Ok(_mapper.Map<ResponseRequest>(comicVM));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Delete a comic
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("{key}")]
        public ActionResult Delete(Guid key)
        {
            try
            {
                var dbComic = _service.Find(key);

                if (dbComic == null)
                {
                    _logger.LogInformation("Invalid Delete :  Comic Not Found");
                    return BadRequest("Comic Not Found");
                }

                _service.Remove(key);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
