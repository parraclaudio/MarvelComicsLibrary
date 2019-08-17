using System;
using System.Collections.Generic;
using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Entity.Values;
using MarvelComicsLibrary.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarvelComicsLibrary.Application.Controllers
{
    /// <summary>
    /// Api for borrow control
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly ILogger<BorrowController> _logger;
        private readonly IMapper _mapper;
        private readonly IBorrowService _service;

        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="logger">Application Log service</param>
        /// <param name="mapper">Automapper service</param>
        /// <param name="service">Borrow Service</param>
        public BorrowController(ILogger<BorrowController> logger, IMapper mapper, IBorrowService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Create a borrow of a Comic
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] BorrowViewModel obj)
        {
            try
            {                
                _logger.LogInformation("Received POST : {@data}", obj);

                var borrow = _mapper.Map<Borrow>(obj);

                var save = _service.Add(borrow);

                var borrowVM = _mapper.Map<BorrowViewModel>(save);

                if (!borrowVM.Valid)
                {
                    _logger.LogInformation("POST Invalid : {@data}", borrowVM);

                    return BadRequest(_mapper.Map<ResponseRequest>(borrowVM));
                }

                _logger.LogInformation("POST OK : {@data}", borrowVM);

                return Ok(_mapper.Map<ResponseRequest>(borrowVM));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }


        /// <summary>
        /// Delete a comic borrow
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("{key}")]
        public ActionResult Delete(Guid key)
        {
            _logger.LogInformation("Delete Borrow " + key);

            return Ok();
        }
    }
}
