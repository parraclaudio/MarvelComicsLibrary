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
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _service;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public BorrowController(IMapper mapper, IBorrowService service)
        {
            _mapper = mapper;
            _service = service;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] BorrowViewModel obj)
        {
            var borrow = _mapper.Map<Borrow>(obj);

            var save = _service.Add(borrow);

            var borrowVM = _mapper.Map<BorrowViewModel>(save);

            if (!borrowVM.Valid)
            {
                return BadRequest(_mapper.Map<ResponseRequest>(borrowVM));
            }

            return Ok(_mapper.Map<ResponseRequest>(borrowVM));
        }


        // DELETE api/values/5
        [HttpDelete("{key}")]
        public ActionResult Delete(Guid key)
        {
            return Ok();
        }
    }
}
