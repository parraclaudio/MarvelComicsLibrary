using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public ActionResult<Guid> Post([FromBody] CustomerViewModel obj)
        {
            var customer = _mapper.Map<Customer>(obj);

           if(!customer.Valid)
            {
                return BadRequest(customer.ValidationResult.Errors);
            }

            _service.Add(customer);

            return Ok(customer.Key);
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public ActionResult Put(Guid key, [FromBody] CustomerViewModel obj)
        {
            var customer = _mapper.Map<Customer>(obj);

            if (!customer.Valid)
            {
                return BadRequest(customer.ValidationResult.Errors);
            }

            _service.Amend(key, customer);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
