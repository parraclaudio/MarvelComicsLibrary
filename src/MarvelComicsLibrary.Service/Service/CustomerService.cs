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
        private readonly ICustomerBusiness _customer;
        
        public CustomerService( ICustomerBusiness customer, IBaseRepository<Customer> repository)
        {
            _customer = customer;
        }

        public List<Customer> GetList()
        {
            return _customer.GetList();
        }

        public Customer Find(Guid key)
        {
            return _customer.Find(key);
        }

        public Customer Add(Customer obj)
        {
            return _customer.Add(obj);
        }

        public Customer Amend(Customer obj)
        {
            return _customer.Amend(obj);
        }
        public void Remove(Guid key)
        {
            _customer.Remove(key);
        }
    }
}
