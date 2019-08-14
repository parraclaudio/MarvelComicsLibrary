﻿using System;
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
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<List<CustomerViewModel>>( _service.GetList() ));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] CustomerViewModel customer)
        {
            _service.Add(_mapper.Map<Customer>(customer));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
