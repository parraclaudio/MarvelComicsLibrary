using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;
using MarvelComicsLibrary.Service.Interface;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IBaseRepository<Customer> _repository;

        public CustomerService(IBaseRepository<Customer> repository)
        {
            _repository = repository;
        }

        public List<Customer> GetList()
        {
            return _repository.GetAll();
        }

        public Customer Find(Guid key)
        {
            return _repository.GetByKey(key);
        }

        public void Add(Customer obj)
        {
            _repository.Insert(obj);
        }

        public void Amend(Customer obj)
        {
            _repository.Update(obj);
        }
    }
}
