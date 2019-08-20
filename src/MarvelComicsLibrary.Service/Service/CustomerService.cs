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
        private readonly IComicBusiness _comic;

        public CustomerService( ICustomerBusiness customer, IComicBusiness comic)
        {
            _comic = comic;
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
