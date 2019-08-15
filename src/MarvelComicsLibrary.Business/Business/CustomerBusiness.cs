using System;
using System.Collections.Generic;
using FluentValidation;
using MarvelComicsLibrary.Business.Interface;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Domain.Validation;
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

        public Customer Save(Customer obj)
        {
            Validate(obj, Activator.CreateInstance<CustomerValidation>());

            if(obj.Valid)
            {
                _repository.Insert(obj);
            }

            return obj;
        }

        public List<Customer> GetList()
        {
            return _repository.GetAll();
        }

        private void Validate(Customer obj, AbstractValidator<Customer> validator)
        {
            obj.ValidationResult = validator.Validate(obj);            
        }
    }
}
