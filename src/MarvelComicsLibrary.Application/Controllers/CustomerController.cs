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
        public ActionResult<List<CustomerViewModel>> Get()
        {
            return Ok(_mapper.Map<List<CustomerViewModel>>( _service.GetList() ));
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public ActionResult<CustomerViewModel> Get(Guid key)
        {
            return Ok(_mapper.Map<CustomerViewModel>(_service.Find(key)));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody] CustomerViewModel obj)
        {
            var customer = _mapper.Map<Customer>( obj );

            var save = _mapper.Map<CustomerViewModel>( _service.Add(customer) );

            if (!ModelState.IsValid)
            {
                return BadRequest( _mapper.Map<ResponseRequest>(save) );
            }

            return Ok( _mapper.Map<ResponseRequest>(save) );
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public ActionResult Put(Guid key, [FromBody] CustomerViewModel obj)
        {
            var dbCustomer = _service.Find(key);

            if(dbCustomer == null)
            {
                return BadRequest("Cliente não encontrado");
            }

            var customer = _mapper.Map<Customer>(obj);

            customer.Id = dbCustomer.Id;
            customer.Key = key;

            var update = _service.Amend(customer);

            if (!update.Valid)
            {
                return BadRequest(customer.ValidationResult.Errors);
            }

            return Ok();
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
