using System;
using System.Collections.Generic;
using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Business.Validation;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Repository.Interface;

namespace MarvelComicsLibrary.Business.Business
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly IBaseRepository<Customer> _repository;

        public CustomerBusiness(IBaseRepository<Customer> repository)
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

        public Customer Add(Customer obj)
        {
            Validate(obj, Activator.CreateInstance<CustomerValidation>());

            if (obj.Valid)
            {
                _repository.Insert(obj);
            }

            return obj;
        }

        public Customer Amend(Customer obj)
        {
            Validate(obj, Activator.CreateInstance<CustomerValidation>());

            if (obj.Valid)
            {
                _repository.Update(obj);
            }

            return obj;
        }

        public void Remove(Guid key)
        {
            _repository.Delete(key);
        }

        private void Validate(Customer obj, AbstractValidator<Customer> validator)
        {
            obj.ValidationResult = validator.Validate(obj);            
        }
    }
}
