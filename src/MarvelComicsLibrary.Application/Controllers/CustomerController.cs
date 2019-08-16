using System;
using System.Collections.Generic;
using AutoMapper;
using MarvelComicsLibrary.Application.Model;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarvelComicsLibrary.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public CustomerController(IMapper mapper, ICustomerService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ResponseRequest>> Get()
        {
            var customerVM = _mapper.Map<List<CustomerViewModel>>( _service.GetList() );

            return Ok(_mapper.Map<ResponseRequest>(customerVM));
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public ActionResult<ResponseRequest> Get(Guid key)
        {
            var customerVM = _mapper.Map<CustomerViewModel>(_service.Find(key));

            return Ok(_mapper.Map<ResponseRequest>(customerVM));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] CustomerViewModel obj)
        {
            var customer = _mapper.Map<Customer>( obj );

            var save =  _service.Add(customer);

            var customerVM = _mapper.Map<CustomerViewModel>( save );

            if (!customerVM.Valid)
            {
                return BadRequest( _mapper.Map<ResponseRequest>(customerVM) );
            }

            return Ok( _mapper.Map<ResponseRequest>(customerVM) );
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public ActionResult<ResponseRequest> Put(Guid key, [FromBody] CustomerViewModel obj)
        {
            var dbCustomer = _service.Find(key);

            if(dbCustomer == null)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(obj);

            customer.Id = dbCustomer.Id;
            customer.Key = key;

            var update = _service.Amend(customer);

            var customerVM = _mapper.Map<CustomerViewModel>(update);

            if (!customerVM.Valid)
            {
                return BadRequest(_mapper.Map<ResponseRequest>(customerVM));
            }

            return Ok(_mapper.Map<ResponseRequest>(customerVM));
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public ActionResult Delete(Guid key)
        {
            var dbCustomer = _service.Find(key);

            if (dbCustomer == null)
            {
                return BadRequest();
            }
            _service.Remove(key);

            return Ok();
        }
    }
}
